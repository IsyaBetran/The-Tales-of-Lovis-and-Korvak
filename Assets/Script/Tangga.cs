using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tangga : MonoBehaviour
{
    private float naik;
    [SerializeField]private float kecepatan;
    private bool adaTangga;
    private bool naikTangga;

    [SerializeField] private Rigidbody2D badan;

    void Update()
    {
        naik = Input.GetAxisRaw("Vertical");

        if (adaTangga && Mathf.Abs(naik) > 0f)
        {
            naikTangga = true;
        }
    }

    private void FixedUpdate()
    {
        if (naikTangga)
        {
            badan.gravityScale = 0f;
            badan.velocity = new Vector2(badan.velocity.x, naik * kecepatan);
            badan.AddForce(Vector2.up * kecepatan);
        }
        else
        {
            badan.gravityScale = 2f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tangga"))
        {
            adaTangga = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tangga"))
        {
            adaTangga = false;
            naikTangga = false;
        }
    }
}
