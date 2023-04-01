using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour {
    public float speed = 3.0f;

    void Update () {
        int randomDirection = Random.Range(0, 4);
        Vector3 direction = Vector3.zero;

        switch (randomDirection) {
            case 0:
                direction = Vector3.forward;
                break;
            case 1:
                direction = -Vector3.forward;
                break;
            case 2:
                direction = Vector3.left;
                break;
            case 3:
                direction = Vector3.right;
                break;
        }

        RaycastHit hit;
        if (!Physics.Raycast(transform.position, direction, out hit, 1.0f) || hit.collider.tag == "Finish") {
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }
}
