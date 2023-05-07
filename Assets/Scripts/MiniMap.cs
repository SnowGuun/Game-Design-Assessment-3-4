using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.miniMapCollected();
            gameObject.SetActive(false);

        }
    }

    private void Update()
    {
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y + 5, this.transform.rotation.z);
    }
}
