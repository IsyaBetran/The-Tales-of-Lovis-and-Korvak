using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float healthAwal;
    public float healthSaatIni { get; private set; }
    private Animator anim;
    public bool dead;
    public bool penuh;
    [SerializeField]private Checkpoint cp;

    [Header("IFrames")]
    [SerializeField] private float durasi;
    [SerializeField] private float banyakFlash;
    private SpriteRenderer sprt;

    void Awake()
    {
        healthSaatIni = healthAwal;
        anim = GetComponent<Animator>();
        sprt = GetComponent<SpriteRenderer>();
    }

    public void KenaDamage (float _damage)
    {
        //method untuk mengurangi darah player
        healthSaatIni = Mathf.Clamp(healthSaatIni - _damage, 0, healthAwal);

        if (healthSaatIni > 0)
        {
            //jika darah masih ada, animasi hurt akan terjadi
            anim.SetTrigger("hurt");
            StartCoroutine(immunity());
        }
        else
        {
            if (!dead)
            {
                //bool dead digunakan di script checkpoint
                dead = true;
                healthSaatIni = healthAwal;
            }
        }
    }

    public void AddHealth(float _value)
    {        
            //method untuk menambah darah
            healthSaatIni = Mathf.Clamp(healthSaatIni + _value, 0, healthAwal);               
    }

    public void FixedUpdate(){
        if(cp.respawn){
            dead = false;
        }
        //mengecek apakah darah penuh atau tidak.
        if(healthSaatIni == healthAwal){
            penuh = true;
        }else{
            penuh = false;
        }
    }

    private IEnumerator immunity()
    {
        Physics2D.IgnoreLayerCollision(3, 10, true);
        for (int i = 0; i < banyakFlash; i++)
        {
            sprt.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(durasi / (banyakFlash * 2));
            sprt.color = Color.white;
            yield return new WaitForSeconds(durasi / (banyakFlash * 2));
        }
        Physics2D.IgnoreLayerCollision(3, 10, false);
    }
}
