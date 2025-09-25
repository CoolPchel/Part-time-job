using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    [SerializeField] GameObject pauseGameMenu;
    private FirstPersonLook fpl;
    public bool pauseGame;

    private void Start()
    {
        fpl = FindObjectOfType<FirstPersonLook>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;
            if(pauseGame)
            {
                PauseGame();
            }
            if(!pauseGame)
            {
                Resume();
            }
        }
    }

    public void ExitMeinMenue()
    {
        SceneManager.LoadScene(0);
    }

    public void ReturneGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        AudioListener.pause = false; //Вкл все звуки сцены
        fpl.canLook = true; //Разрешаю вертеть камерой
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f; //Востанавливает время
        pauseGame = false;
    }

    private void PauseGame()
    {
        pauseGameMenu.SetActive(true);
        AudioListener.pause = true; //Выкл все звуки сцены
        fpl.canLook = false; //Запрещаю вертеть камерой
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f; //Остонавливает время
    }
}
