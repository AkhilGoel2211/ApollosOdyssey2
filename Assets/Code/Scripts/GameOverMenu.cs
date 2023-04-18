using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
	public Slider slider;
    public bool gameOver = false;

    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    void Update() 
    {
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
