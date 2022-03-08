using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiKarakter : MonoBehaviour
{
    private Animator anim;
    private float jalan;
    private float kecepatan = 5f;
    Transform t;
    [SerializeField]private PlayerMovement player;
    [SerializeField]private PlayerInteraction playerIn;

    public bool diBawah;
    public Transform cekBawah;
    public float cekKejauhan;
    public LayerMask bawahnya;


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

        

        diBawah = Physics2D.OverlapCircle(cekBawah.position, cekKejauhan, bawahnya);
        if(player.diTanah || diBawah){
            anim.SetBool("Jump", false);
            anim.SetBool("Jatuh", false);
        }else if(Input.GetKeyDown(KeyCode.Space) && diBawah && playerIn.pegang == false){
            anim.SetTrigger("Takeoff");
        }else if(player.diTanah == false && Input.GetKeyDown(KeyCode.Space) == false){
            anim.SetBool("Jatuh", true);
        }else{
            anim.SetBool("Jump", true);
        }
        
        
        if(playerIn.pegang){
            anim.SetBool("Dorong", true);
        }else{
            anim.SetBool("Dorong", false);
        }
    }
    
}
