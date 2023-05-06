using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Tutorial()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void Level1()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void Level2()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }

    public void Level3()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
