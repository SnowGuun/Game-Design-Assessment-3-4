using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string colour;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        Debug.Log("collided");
        if (playerInventory != null)
        {
            
            playerInventory.keyCollected(colour);
            gameObject.SetActive(false);
        }
    }
}
