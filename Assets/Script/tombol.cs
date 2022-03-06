using UnityEngine;

public class tombol : MonoBehaviour
    //Script yang berjalan jika tombol di injak
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
            //tombol menjadi transparan dan memberikan kesan seperti diinjak
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            pressed = true;
                       
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //tombol muncul setelah tidak diinjak
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);     
    }

}
