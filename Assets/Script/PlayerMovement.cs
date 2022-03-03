using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D badan;
    Transform t;
    private float fixedRotation = 0;

    [SerializeField]private float kecepatan;
    private void Awake(){
        badan = GetComponent<Rigidbody2D>();
        t = transform;
    }

    private void Update(){
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

        //lompat
        if(Input.GetKey(KeyCode.Space)){
            badan.velocity = new Vector2(badan.velocity.x, kecepatan);
        }
    }
}
