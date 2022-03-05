using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private float tambahHealth;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponentInChildren<Health>().AddHealth(tambahHealth);
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        
    }
}
