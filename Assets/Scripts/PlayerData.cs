using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private Vector3 startingPosition;
    private bool tagged = false;
    public void setTagged(bool boolean){ tagged = boolean; }

    void Start()
    {
        startingPosition = new Vector3(20, 11, 20);
        tagged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(tagged){
            Debug.Log("flag");
            this.transform.TransformPoint(startingPosition);
            tagged = false;
        }
    }
}
