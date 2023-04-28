using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI bookText;
    [SerializeField] private TextMeshProUGUI staminaText = default;

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
        UpdateStamina(30);

    }

   
    public void UpdateBookText(PlayerInventory playerInventory)
    {
        bookText.text = playerInventory.NumberOfBooks.ToString();
    }

    private void UpdateStamina(float currentStamina)
    {
        staminaText.text = currentStamina.ToString("00");
    }
}
