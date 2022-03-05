using UnityEngine;

public class tombol : MonoBehaviour
{
    public Renderer r;
    public bool pressed = false;

    private void Awake()
    {
        r = GetComponent<Renderer>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            pressed = true;
                       
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);     
    }

}
