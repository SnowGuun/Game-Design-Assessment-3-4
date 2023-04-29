using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition
{
    GameOverMenu gameOverMenuScript;

    void Start()
    {
        gameOverMenuScript = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOverMenu>();
        
    }

    public static void lose(){
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //GameOverCanvas.GetComponent<GameOverMenu>().GameOver();
        //gameOverMenuScript.GameOver();
    }
}
