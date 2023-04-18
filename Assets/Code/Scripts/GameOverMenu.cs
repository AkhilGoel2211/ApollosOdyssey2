using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private LeaderboardManager scoreManager;
    private GameObject leaderBoardTitle;
    private float shiftHeight = 30;
    [SerializeField] private GameObject leaderboardEntry;
    void OnEnable()
    {
        Debug.Log("Logging current max scores : ");
        scoreManager = GameObject.Find("Terrain").GetComponent<LeaderboardManager>();
        leaderBoardTitle = GameObject.Find("Entries");
        Vector3 titleCoords = leaderBoardTitle.transform.position;
        List<LeaderboardEntry> leaderBoardEntries = scoreManager.GetTopScores();
        Debug.Log("Leaderboard items : " + leaderBoardEntries.Count.ToString());
        for (int i = 0; i < leaderBoardEntries.Count; i++)
        {
            Debug.Log("Leadertitle : " + "X = " + titleCoords.x + " Y =" + titleCoords.y + " Z=" + titleCoords.z);
            GameObject entry = Instantiate(leaderboardEntry, titleCoords - new Vector3(0,i*shiftHeight,0), Quaternion.identity,leaderBoardTitle.transform);
            entry.transform.Find("Kills").GetComponent<Text>().text = leaderBoardEntries[i].score.ToString();
            entry.transform.Find("Date").GetComponent<Text>().text = leaderBoardEntries[i].dateTime;
        }
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
