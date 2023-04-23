using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public Transform player;
    public float dist;
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);
        if(Vector3.Distance(player.position, transform.position) <= 10){
            PlayerInventory pI = player.gameObject.GetComponent<PlayerInventory>();
            Debug.Log("close enough");
            if(pI.NumberOfBooks >= 3){
                Debug.Log("Enough Books");
                LoseCondition.lose();
            }
        }
    }
}
