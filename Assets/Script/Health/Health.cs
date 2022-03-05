using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthAwal;
    public float healthSaatIni { get; private set; }
    private Animator anim;
    private bool dead;

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
                anim.SetTrigger("die");
                GetComponentInParent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            KenaDamage(0.5f);
    }


}
