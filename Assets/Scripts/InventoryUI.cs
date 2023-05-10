using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    
    private TextMeshProUGUI bookText;
   
     [SerializeField] private TextMeshProUGUI staminaText;
    [SerializeField] private GameObject image;

    private void OnEnable()
    {
        FirstPersonController.onStaminaChange += UpdateStamina;
    }

    private void OnDisable()
    {
        FirstPersonController.onStaminaChange -= UpdateStamina;
    }
    // Start is called before the first frame update
    private void Start()
    {
        bookText = GetComponent<TextMeshProUGUI>();
        UpdateStamina(100);


    }

   
    public void UpdateBookText(PlayerInventory playerInventory)
    {
        bookText.text = playerInventory.NumberOfBooks.ToString() + " / 3";
        
        // if (playerInventory.NumberOfBooks == 3) 
        // {
           
        //     bookText.text = "Go to the Finish";
           
        // }
    }

    private void UpdateStamina(float currentStamina)
    {
       //  staminaText.text = currentStamina.ToString("00");
    }
}
