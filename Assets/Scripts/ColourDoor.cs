using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourDoor : MonoBehaviour
{
    public string colour;
    [SerializeField] private int openPos;
    [SerializeField] private GameObject player;
    private PlayerInventory pI;
    public MazeData mD;

    void Start(){
        pI = player.GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if(colour == "red"){
            if(pI.redCollected){ gameObject.SetActive(false); mD.setTile((int)transform.position.x/10, (int)transform.position.z/10, 0); }
        }
        else if(colour == "blue"){
            if(pI.blueCollected){ gameObject.SetActive(false); mD.setTile((int)transform.position.x/10, (int)transform.position.z/10, 0); }
        }
    }
}
