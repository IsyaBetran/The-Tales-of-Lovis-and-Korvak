using UnityEngine;

//  script untuk interaksi yang bisa  dilakukan player
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float jarak;
    GameObject kotak;
    public LayerMask boxMask;

    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, jarak, boxMask);

        if (hit.collider != null && Input.GetKeyDown(KeyCode.E))
        {
            kotak = hit.collider.gameObject;
            kotak.GetComponent<FixedJoint2D>().enabled = true;
            kotak.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            kotak.GetComponent<FixedJoint2D>().enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * jarak); 
    }
}
