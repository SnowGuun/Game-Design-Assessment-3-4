using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    
    private TextMeshProUGUI bookText;
   
    // [SerializeField] private TextMeshProUGUI staminaText;
   // [SerializeField] private GameObject image;
   // [SerializeField] private GameObject player;

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
      //  UpdateStamina(30);


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
      //  GameObject player = GameObject.Find("Player");
      //  FirstPersonController fpc = player.GetComponent<FirstPersonController>();

      //  staminaText.text = fpc.getStamina().ToString("00");
        //staminaText.text = temp + "";
       // temp--;
    }
   // public float temp = 10;
}
