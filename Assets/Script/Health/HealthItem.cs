using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private float tambahHealth;
    public Health health;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && health.penuh == true)
        {
            collision.GetComponentInChildren<Health>().AddHealth(tambahHealth);
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        
    }
}
