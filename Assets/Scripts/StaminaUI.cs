using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StaminaUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI staminaText;
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

        UpdateStamina(30);


    }
    private void UpdateStamina(float currentStamina)
    {
        GameObject player = GameObject.Find("Player");
        FirstPersonController fpc = player.GetComponent<FirstPersonController>();

        staminaText.text = "Stamina: " + fpc.getStamina().ToString("00");
        //staminaText.text = temp + "";
        temp--;
    }
    public float temp = 10;
}