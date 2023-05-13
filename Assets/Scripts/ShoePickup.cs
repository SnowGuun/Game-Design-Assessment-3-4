using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoePickup : MonoBehaviour
{
    public AudioClip collectedSound;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.shoeCollected();
            AudioSource.PlayClipAtPoint(collectedSound, transform.position);
            gameObject.SetActive(false);
        }
        // if (other.CompareTag("Player"))
        // {
        //     gameObject.SetActive(false);

        //     // Get the FirstPersonController component attached to the player
        //     FirstPersonController fpc = other.GetComponent<FirstPersonController>();

        //     // Enable the jump functionality sby setting the isJumpEnabled flag to true
        //     fpc.isJumpEnabled = true;


        // }
    }
}

