using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public AudioClip collectedSound;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.miniMapCollected();
            AudioSource.PlayClipAtPoint(collectedSound, transform.position);
            gameObject.SetActive(false);

        }
    }
}
