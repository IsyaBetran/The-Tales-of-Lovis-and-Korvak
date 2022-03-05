using UnityEngine;

public class pintu : MonoBehaviour
{
    [SerializeField] private Transform pos1, pos2, posAwal;
    [SerializeField] private float kecepatanBuka;
    Vector3 nextPos;
    

    private void Start()
    {
        nextPos = posAwal.position;
    }
    public void BukaPintu()
    {
        if (transform.position != pos2.position)
            nextPos = pos2.position;
        transform.position = Vector3.MoveTowards(transform.position, nextPos, kecepatanBuka * Time.deltaTime);
    }

    private void Update()
    {
        if (GameObject.Find("tombol").GetComponent<tombol>().pressed == true)
            BukaPintu();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
