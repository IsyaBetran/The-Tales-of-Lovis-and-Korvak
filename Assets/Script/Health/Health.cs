using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthAwal;
    public float healthSaatIni { get; private set; }
    private Animator anim;
    public bool dead;

    void Awake()
    {
        healthSaatIni = healthAwal;
        anim = GetComponent<Animator>();
    }

    public void KenaDamage (float _damage)
    {
        healthSaatIni = Mathf.Clamp(healthSaatIni - _damage, 0, healthAwal);

        if (healthSaatIni > 0)
        {
            anim.SetTrigger("hurt");
            //iframes
        }
        else
        {
            if (!dead)
            {
                dead = true;
                healthSaatIni = healthAwal;
            }
        }
    }

    public void AddHealth(float _value)
    {
        healthSaatIni = Mathf.Clamp(healthSaatIni + _value, 0, healthAwal);
    }
}
