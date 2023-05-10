using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfBooks { get; private set; }
    public bool minimapCollected { get; private set; }
    public bool redCollected { get; private set; }
    public bool blueCollected { get; private set; }

    public UnityEvent<PlayerInventory> onBookCollected;
    public UnityEvent<PlayerInventory> onKeyCollected;
    public UnityEvent<PlayerInventory> onMiniMapCollected;

    [SerializeField] GameObject minimap, minimapBorder;

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
        // if (minimapCollected.)
    }
}
