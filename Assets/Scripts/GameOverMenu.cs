using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static bool isGameOver = false;

    public Transform Players;

    [SerializeField] GameObject gameOverMenu;

    CursorLockMode desiredModes;

    void Start()
    {
        GameNotOver();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isGameOver)
            {

                GameNotOver(); 
            }
            else
            {
                GameOver();
            }
        }
    }
   
    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
        Players.GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        desiredModes = CursorLockMode.None;
        {
            Cursor.lockState = desiredModes;
        }
        Debug.Log("game over");
    }


    public void GameNotOver()
    {

        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        isGameOver = false;
        Players.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        desiredModes = CursorLockMode.Confined;
        Debug.Log("game not over");
       }

    public void RestartLevel()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
       

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;


    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
