using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoePickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FirstPersonController playerController = other.GetComponent<FirstPersonController>();
            if (playerController != null)
            {

                playerController.EnableSprinting();
                Destroy(gameObject);

            }
            
        }
    }
}

