using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoseCondition
{
    public static void lose(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
