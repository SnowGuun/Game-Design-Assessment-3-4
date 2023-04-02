using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    public Transform Player;
    public float distance = 5.0f;
    public float speed = 2.0f;

    void Update()
    {
        Vector3 playerPos = Player.position;
        playerPos.x += distance;
        transform.position = Vector3.Lerp(transform.position, playerPos, speed * Time.deltaTime);
        
    }
}

