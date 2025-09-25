using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewAndExit : MonoBehaviour
{
    public void StartNewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
