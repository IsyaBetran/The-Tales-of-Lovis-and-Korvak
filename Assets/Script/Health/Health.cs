using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthAwal;
    public float healthSaatIni { get; private set; }
    private Animator anim;
    public bool dead;
    public bool penuh;

    void Awake()
    {
        healthSaatIni = healthAwal;
        anim = GetComponent<Animator>();
    }

    public void KenaDamage (float _damage)
    {
        //method untuk mengurangi darah player
        healthSaatIni = Mathf.Clamp(healthSaatIni - _damage, 0, healthAwal);

        if (healthSaatIni > 0)
        {
            //jika darah masih ada, animasi hurt akan terjadi
            anim.SetTrigger("hurt");
            //iframes
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

    public void Update(){
        //mengecek apakah darah penuh atau tidak.
        if(healthSaatIni == healthAwal){
            penuh = true;
        }else{
            penuh = false;
        }
    }
}
