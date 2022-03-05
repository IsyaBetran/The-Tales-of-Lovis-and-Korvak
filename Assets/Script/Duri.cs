using UnityEngine;

public class Duri : MonoBehaviour
{
   [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponentInChildren<Health>().KenaDamage(damage);
        }
    }
}
