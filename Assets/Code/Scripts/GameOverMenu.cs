using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private LeaderboardManager scoreManager;
    void OnEnable()
    {
        Debug.Log("Logging current max scores : ");
        scoreManager = GameObject.Find("Terrain").GetComponent<LeaderboardManager>();
        List<LeaderboardEntry> leaderBoardEntries = scoreManager.GetTopScores();
        Debug.Log("Leaderboard items : " + leaderBoardEntries.Count.ToString());
        for (int i = 0; i < leaderBoardEntries.Count; i++)
        {
            Debug.Log(leaderBoardEntries[i].score.ToString() + " : " + i.ToString());
        }
    }
    //void Start()
    //{
        
    //}

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
