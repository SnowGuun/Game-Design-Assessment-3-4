using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfBooks { get; private set; }
    public bool minimapCollected { get; private set; }
    public bool isShoeCollected {get; private set; }
    public bool redCollected { get; private set; }
    public bool blueCollected { get; private set; }

    public UnityEvent<PlayerInventory> onBookCollected;
    public UnityEvent<PlayerInventory> onKeyCollected;
    public UnityEvent<PlayerInventory> onMiniMapCollected;
    public UnityEvent<PlayerInventory> onShoeCollected;

    [SerializeField] GameObject minimap, minimapBorder; 

    public bool rkBegin, bkBegin, sBegin, mBegin;
    void Start(){
        minimapCollected = mBegin;
        redCollected = rkBegin;
        blueCollected = bkBegin;
        isShoeCollected = sBegin;
        if(sBegin){ 
            FirstPersonController fpc = this.gameObject.GetComponent<FirstPersonController>();
            fpc.isJumpEnabled = true;
        }
    }

    public void BookCollected()
    {
        NumberOfBooks++;
        onBookCollected.Invoke(this);
    }

    public void keyCollected(string colour){
        if(colour == "red"){ redCollected = true; }
        else if(colour == "blue"){ blueCollected = true; }
        onKeyCollected.Invoke(this);
    }

    public void miniMapCollected()
    {
        minimap.SetActive(true);
        minimapBorder.SetActive(true);
        minimapCollected = true;
        onMiniMapCollected.Invoke(this);
        // if (minimapCollected.)
    }

    public void shoeCollected(){
        FirstPersonController fpc = this.gameObject.GetComponent<FirstPersonController>();
        fpc.isJumpEnabled = true;
        isShoeCollected = true;
        onShoeCollected.Invoke(this);
    }
}
