using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable() 
    {
        PlayerHealth.OnPlayerDeath += EnableGameOverMenu;
    }
 
    private void OnDisable() 
    {
        PlayerHealth.OnPlayerDeath -= EnableGameOverMenu;
    }

    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    void Update() 
    {
        // if (gameOverMenu != null)
        // {
        //     Cursor.lockState = CursorLockMode.None;
        //     Cursor.visible = true;
        // } 
        // else
        // {
        //     Cursor.lockState = CursorLockMode.Locked;
        //     Cursor.visible = false;
        // }
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
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
