using UnityEngine;

public class Duri : MonoBehaviour
{
   [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log(GameObject.Find("player").GetComponent<Health>());
            collision.GetComponentInChildren<Health>().KenaDamage(damage);
        }
    }
}
