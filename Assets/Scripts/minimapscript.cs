using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapscript : MonoBehaviour
{
    public Transform player;
    public Transform playerCamera;

    private void Start()
    {
        playerCamera = player.GetComponentInChildren<Camera>().transform;
    }


    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90.0f, playerCamera.rotation.eulerAngles.y, 0.0f);


    }
}
