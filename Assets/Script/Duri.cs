using UnityEngine;

public class Duri : MonoBehaviour
{
    //script untuk trap duri
   [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //jika terkena duri, akan memanggil method untuk mengurangi nyawa
            Health a = GetComponentInChildren<Health>();
            collision.GetComponentInChildren<Health>().KenaDamage(damage);
        }
    }
}
