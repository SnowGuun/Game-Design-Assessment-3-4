using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static bool isGameOver = false;

    public Transform Player;

    [SerializeField] GameObject gameOverMenu;

    CursorLockMode desiredMode;


    void update()
    {
        if (isGameOver)
        {
            GameOver();
        }
        else
        {
            GameNotOver();
        }
    }

    public void GameOver()
    {
        isGameOver = false;
        Cursor.visible = false;
        desiredMode = CursorLockMode.Confined;
    }

    public void GameNotOver()
    {
        isGameOver = false;
        Cursor.visible = true;
        desiredMode = CursorLockMode.None;
        {
            Cursor.lockState = desiredMode;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
