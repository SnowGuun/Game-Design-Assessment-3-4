using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public AudioClip collectedSound;
    public string colour;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        Debug.Log("collided");
        if (playerInventory != null)
        {
            
            playerInventory.keyCollected(colour);
            AudioSource.PlayClipAtPoint(collectedSound, transform.position);
            gameObject.SetActive(false);
        }
    }
}
