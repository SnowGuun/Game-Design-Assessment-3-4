using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptEnabler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject prompt;
    [SerializeField] private GameObject altPrompt;
    [SerializeField] private GameObject promptBackDrop;
    public bool promptActive = false;
    private float timer = 2;
    private void OnTriggerEnter(Collider other) {
        if(other.transform.name == "Player"){
            if(altPrompt == null){
                prompt.SetActive(true);
                promptBackDrop.SetActive(true);
                Time.timeScale = 0.0f;
                promptActive = true;
            }
            else{
                PlayerInventory pI = player.gameObject.GetComponent<PlayerInventory>();
                if(pI.NumberOfBooks >= 3){
                    prompt.SetActive(true);
                    promptBackDrop.SetActive(true);
                    Time.timeScale = 0.0f;
                    promptActive = true;
                }
                else{
                    altPrompt.SetActive(true);
                    promptBackDrop.SetActive(true);
                    Time.timeScale = 0.0f;
                    promptActive = true;
                }
            }
        }
    }

    void Update()
    {
        if(promptActive){
            if(timer <= 0){
                if(Input.anyKeyDown){
                    if(altPrompt != null){ altPrompt.SetActive(false); }
                    prompt.SetActive(false);
                    promptBackDrop.SetActive(false);
                    promptActive = false;
                    Time.timeScale = 1.0f;
                }
            }
            else{
                timer -= 1 * Time.unscaledDeltaTime;
            }
        }
    }
}
