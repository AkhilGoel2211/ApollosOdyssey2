using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScore : MonoBehaviour
{
    private int killCount;
    public Text counterText;

    private int playerScore;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
        playerScore = 0;
        counterText.text = killCount.ToString();
        scoreText.text = playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        refreshKills();
        refreshScore();
    }

    public void incrementKills()
    {
        killCount += 1;
    }

    public void refreshKills()
    {
        counterText.text = killCount.ToString();
    }

    public void refreshScore()
    {
        scoreText.text = playerScore.ToString();
    }

    public void Bodyshot()
    {
        playerScore += 20;
    }

    public void Headshot() 
    {
        playerScore += 50;
    }

    public int getKills()
    {
        return killCount;
    }

    public int getPlayerScore()
    {
        return playerScore;
    }
}
