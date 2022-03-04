using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D badan;
    Transform t;
    public float tinggiLompat;

    [SerializeField]private float kecepatan;

    private bool diTanah;
    public Transform cekTanah;
    public float cekKejauhan;
    public LayerMask tanahnya;

    public LayerMask tangga;
    private bool naikTangga;

    private float lompat = 1;

    private void Awake(){
        badan = GetComponent<Rigidbody2D>();
        t = transform;
    }

    private void Update(){
        //berjalan
        var jalan = Input.GetAxis("Horizontal");
        badan.velocity = new Vector2(jalan * kecepatan, badan.velocity.y);

        RaycastHit2D kena = Physics2D.Raycast(transform.position, Vector2.up, cekKejauhan, tangga);
        if(kena.collider != null){
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                naikTangga =  true;
            }       
        }else{
            naikTangga = false;
        }

        if(naikTangga == true){
            var naik = Input.GetAxis("Vertical");
            badan.velocity = new Vector2(badan.position.x, naik * kecepatan);
            badan.gravityScale = 0f;
        }else{
            badan.gravityScale = 2f;
        }
        
        //balik badan
        if(jalan > 0.01f){
            transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        }else if(jalan < -0.01f){
            transform.localScale = new Vector3(-0.15f, 0.15f, 0.15f);
        }  
        diTanah = Physics2D.OverlapCircle(cekTanah.position, cekKejauhan, tanahnya);
        //Double Jump
        if(diTanah == true){
            lompat = 1;
        }
        //lompat
        if(Input.GetKeyDown(KeyCode.Space) && lompat > 0){
            badan.velocity = new Vector2(badan.velocity.x, tinggiLompat);
            lompat--;
        }  
    }
}
