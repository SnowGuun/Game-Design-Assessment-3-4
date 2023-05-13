using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    public Transform player;
    public float dist;
    public bool triggered;
    public bool needMap, needShoe, needKey;
    private float rotation;
    void Update()
    {
        if(!triggered){
            dist = Vector3.Distance(player.position, new Vector3(transform.position.x + 5, 5, transform.position.z - 5));
            if(Vector3.Distance(player.position, new Vector3(transform.position.x + 12, 5, transform.position.z - 5)) <= 10){
                PlayerInventory pI = player.gameObject.GetComponent<PlayerInventory>();
                bool conditionsMet = true;
                if(pI.NumberOfBooks < 3){ conditionsMet = false; }
                if(needMap && !pI.minimapCollected){ conditionsMet = false; }
                if(needShoe && !pI.isShoeCollected){ conditionsMet = false; }
                if(needKey && !pI.redCollected){ conditionsMet = false; }
                if(needKey && !pI.blueCollected){ conditionsMet = false; }
                if(conditionsMet){
                    triggered = true;
                    rotation = 180;
                }
            }   
        }
        else{
            if(rotation > 90){
                rotation -= 45 * Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, rotation, transform.rotation.z),  Time.deltaTime * 45);
            }
        }
    }
}
