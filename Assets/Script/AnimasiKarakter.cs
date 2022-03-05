using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiKarakter : MonoBehaviour
{
    private Animator anim;
    private float jalan;
    private float kecepatan = 5f;
    Transform t;

    void Awake()
    {
        anim = GetComponent<Animator>();
        t = transform;
    }

    // Update is called once per frame
    void Update()
    {
        jalan = Input.GetAxis("Horizontal");
        // animasi
        if(Mathf.Abs(jalan * kecepatan) > 0){
            anim.SetBool("Berjalan", true);
        }else{
            anim.SetBool("Berjalan", false);
        }
    }
    
}
