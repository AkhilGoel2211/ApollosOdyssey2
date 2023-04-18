using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
	public Slider slider;
    public static bool gameOver = false;

    void Start()
    {
        gameOverMenu.SetActive(gameOver);
    }

    void Update() 
    {
        if (gameOver && gameOverMenu != null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } 
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (slider.value == 0)
        {
            gameOverMenu.SetActive(true);
        }
        else
        {
            gameOverMenu.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
