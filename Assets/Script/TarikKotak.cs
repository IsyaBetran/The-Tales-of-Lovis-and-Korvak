using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarikKotak : MonoBehaviour
{
    public bool ditarik;
    float posX;
    void Start()
    {
        posX = transform.position.x;
    }

    void Update()
    {
        if (!ditarik)
            transform.position = new Vector3(posX, transform.position.y);
        else
            posX = transform.position.x;
    }
}
