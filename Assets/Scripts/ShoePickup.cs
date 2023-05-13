using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoePickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            // Get the FirstPersonController component attached to the player
            FirstPersonController fpc = other.GetComponent<FirstPersonController>();

            // Enable the jump functionality sby setting the isJumpEnabled flag to true
            fpc.isJumpEnabled = true;


        }
    }
}

