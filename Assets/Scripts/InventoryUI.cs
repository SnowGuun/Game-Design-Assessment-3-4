using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI bookText;

    // Start is called before the first frame update
    void Start()
    {
        bookText = GetComponent<TextMeshProUGUI>();
    }

   public void UpdateBookText(PlayerInventory playerInventory)
    {
        bookText.text = playerInventory.NumberOfBooks.ToString();
    }
}
