using UnityEngine;

//  script untuk interaksi yang bisa  dilakukan player
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float jarak;
    GameObject kotak;
    public LayerMask boxMask;
    public bool pegang;
    public Transform cekKaki;
    private bool diTanah;
    public float cekKejauhan;
    public LayerMask tanahnya;

    private void Update()
    {
        //mendeteksi apakah didepan player ada kotak atau tidak
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, jarak, boxMask);
        diTanah = Physics2D.OverlapCircle(cekKaki.position, cekKejauhan, tanahnya);

        if (hit.collider != null && Input.GetKeyDown(KeyCode.E) && diTanah)
        {
            //jika didepan player ada kotak dan player menekan tombol E, kotak akan fixed join permframe tepat disamping player
            kotak = hit.collider.gameObject;
            kotak.GetComponent<FixedJoint2D>().enabled = true;
            kotak.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            pegang = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            //jika tombol E dilepas, kotak tidak fixedjoined
            kotak.GetComponent<FixedJoint2D>().enabled = false;
            pegang = false;
        }
    }

    private void OnDrawGizmos()
    {
        //menggambar garis untuk melihat raycast player
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * jarak); 
    }
}
