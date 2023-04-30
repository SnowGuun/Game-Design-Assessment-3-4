using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private MazeData mD;

    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        int pX = (int)(((transform.position.x - ((transform.position.x + 5) % 10)) / 10) + 1);
        int pZ = (int)(((transform.position.z - ((transform.position.z + 5) % 10)) / 10) + 1);

        bool cen = mD.miniMapWall(pX, pZ);
        bool up = mD.miniMapWall(pX, pZ+1);
        bool down = mD.miniMapWall(pX, pZ-1);
        bool left = mD.miniMapWall(pX-1, pZ);
        bool right = mD.miniMapWall(pX+1, pZ);

        if(cen){ GameObject.Find(pX + ":" + pZ).GetComponent<Renderer>().material.color = Color.red; }
        else{ GameObject.Find(pX + ":" + pZ).GetComponent<Renderer>().material.color = Color.black; }

        if(up){ GameObject.Find(pX + ":" + (pZ+1)).GetComponent<Renderer>().material.color = Color.red; }
        else{ GameObject.Find(pX + ":" + (pZ+1)).GetComponent<Renderer>().material.color = Color.black; }

        if(down){ GameObject.Find(pX + ":" + (pZ-1)).GetComponent<Renderer>().material.color = Color.red; }
        else{ GameObject.Find(pX + ":" + (pZ-1)).GetComponent<Renderer>().material.color = Color.black; }
        
        if(left){ GameObject.Find((pX-1) + ":" + pZ).GetComponent<Renderer>().material.color = Color.red; }
        else{ GameObject.Find((pX-1) + ":" + pZ).GetComponent<Renderer>().material.color = Color.black; }

        if(right){ GameObject.Find((pX+1) + ":" + pZ).GetComponent<Renderer>().material.color = Color.red; }
        else{ GameObject.Find((pX+1) + ":" + pZ).GetComponent<Renderer>().material.color = Color.black; }
        
    }
}
