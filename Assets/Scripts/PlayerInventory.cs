using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfBooks { get; private set; }

    public void BookCollected()
    {
        NumberOfBooks++;
    }
}
