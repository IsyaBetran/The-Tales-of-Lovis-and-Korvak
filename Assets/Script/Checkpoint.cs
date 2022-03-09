using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Health darah;
    private Vector3 lokasi;
    public bool respawn;
    // Start is called before the first frame update
    void Start()
    {
        lokasi = transform.position;
    }

    public void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.tag == "Checkpoint"){
            lokasi = transform.position;}
    }
    private void FixedUpdate() {
        if(darah.dead){
            transform.position = lokasi;
            respawn = true;
        }
    }
}
