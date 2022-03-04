using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [Range(1,10)]
    public float halus;

    public void FixedUpdate(){
        Follow();
    }

    public void Follow(){
        Vector3 posisiPlayer = player.position + offset;
        Vector3 lembut = Vector3.Lerp(transform.position, posisiPlayer, halus * Time.fixedDeltaTime);
        transform.position = lembut;
    }
}
