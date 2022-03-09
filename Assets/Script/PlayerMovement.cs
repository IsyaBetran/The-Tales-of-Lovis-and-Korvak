using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
<<<<<<< Updated upstream
    private float jalan;
    private float naik;
    public Rigidbody2D badan { get; private set; }
=======
    public Rigidbody2D badan;
>>>>>>> Stashed changes
    Transform t;
    public float tinggiLompat;

    [SerializeField]private float kecepatan;

    public bool diTanah;
    public Transform cekTanah;
    public float cekKejauhan;
    public LayerMask tanahnya;

    private float lompat = 1;
    [SerializeField]private PlayerInteraction playerIn;
    private Vector3 lastPosition;

    private void Awake()
    {
        badan = GetComponent<Rigidbody2D>();
        t = transform;
    }

<<<<<<< Updated upstream
    private void Update(){    
        //berjalan
        jalan = Input.GetAxis("Horizontal");
        badan.velocity = new Vector2(jalan * kecepatan, badan.velocity.y);   

        //balik badan
        if(playerIn.pegang){
            transform.localScale = lastPosition;
        }else if(jalan > 0.01f){
            transform.localScale = new Vector3(1, 1, 1);
            lastPosition = transform.localScale;
        }else if(jalan < -0.01f){
            transform.localScale = new Vector3(-1, 1, 1);
            lastPosition = transform.localScale;
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
=======
    public void Update(){
        //Double Jump
        if(diTanah == true){
            lompat = 2;
        }
        //lompat
        if(Input.GetKeyDown(KeyCode.Space) && lompat > 0){
            badan.velocity = new Vector2(badan.velocity.x, kecepatan);
            lompat--;
        }

        diTanah = Physics2D.OverlapCircle(cekTanah.position, cekKetinggian, tanahnya);

        //berjalan
        var jalan = Input.GetAxis("Horizontal");
        badan.velocity = new Vector2(Input.GetAxis("Horizontal") * kecepatan, badan.velocity.y);

        //fixed rotation (Biar gk muter-muter)
        t.eulerAngles = new Vector3(t.eulerAngles.x, t.eulerAngles.y, fixedRotation);

        //balik badan
        if (jalan > 0.01f)
        {
            transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        }
        else if (jalan < -0.01f)
        {
            transform.localScale = new Vector3(-0.15f, 0.15f, 0.15f);
>>>>>>> Stashed changes
        }
        
        
    }
}
