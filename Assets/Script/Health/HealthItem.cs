using UnityEngine;

public class HealthItem : MonoBehaviour
{
    //script untuk item penambah darah
    [SerializeField] private float tambahHealth;
    public Health health;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !health.penuh)
        {
            //jika player menyentuh item dan darahnya tidak penuh, darahnya akan ditambah
            collision.GetComponentInChildren<Health>().AddHealth(tambahHealth);
            gameObject.SetActive(false);
        }
    }
}
