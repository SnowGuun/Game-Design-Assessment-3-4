using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfBooks { get; private set; }

    public UnityEvent<PlayerInventory> onBookCollected;

    public void BookCollected()
    {
        NumberOfBooks++;
        onBookCollected.Invoke(this);
    }
}
