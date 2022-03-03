using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D badan;
    Transform t;
    private float fixedRotation = 0;
    public float gravitasi;

    [SerializeField]private float kecepatan;

    private bool diTanah;
    public Transform cekTanah;
    public float cekKetinggian;
    public LayerMask tanahnya;

    private float lompat = 1;

    private void Awake(){
        badan = GetComponent<Rigidbody2D>();
        t = transform;
    }

    private void FixedUpdate(){
        diTanah = Physics2D.OverlapCircle(cekTanah.position, cekKetinggian, tanahnya);

        //berjalan
        var jalan = Input.GetAxis("Horizontal");
        badan.velocity = new Vector2(jalan * kecepatan, badan.velocity.y);

        //fixed rotation (Biar gk muter-muter)
        t.eulerAngles = new Vector3 (t.eulerAngles.x, t.eulerAngles.y, fixedRotation);

        //balik badan
        if(jalan > 0.01f){
            transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        }else if(jalan < -0.01f){
            transform.localScale = new Vector3(-0.15f, 0.15f, 0.15f);
        }

        
    }

    public void Update(){
        //Double Jump
        if(diTanah == true){
            lompat = 1;
        }
        //lompat
        if(Input.GetKeyDown(KeyCode.Space) && lompat > 0){
            badan.velocity = new Vector2(badan.velocity.x, kecepatan);
            lompat--;
        }
    }
}
