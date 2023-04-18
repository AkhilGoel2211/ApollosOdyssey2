using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeaderboardManager : MonoBehaviour
{
    private string filePath;
    private List<LeaderboardEntry> leaderboardEntries;

    private void Awake()
    {
        // Set the file path for the leaderboard JSON file
        filePath = Application.persistentDataPath + "/leaderboard.json";

        // Load the leaderboard entries from the JSON file
        LoadLeaderboardEntries();
    }

    private void LoadLeaderboardEntries()
    {
        // Check if the JSON file exists
        if (File.Exists(filePath))
        {
            // Read the contents of the file
            string json = File.ReadAllText(filePath);

            // Deserialize the JSON data into a list of LeaderboardEntry objects
            leaderboardEntries = JsonUtility.FromJson<List<LeaderboardEntry>>(json);
        }
        else
        {
            // If the file does not exist, create a new empty list of leaderboard entries
            leaderboardEntries = new List<LeaderboardEntry>();
        }
    }

    private void SaveLeaderboardEntries()
    {
        // Serialize the leaderboard entries to JSON
        string json = JsonUtility.ToJson(leaderboardEntries);

        // Write the JSON data to the file
        File.WriteAllText(filePath, json);
    }

    public void AddScore(int score)
    {
        // Create a new leaderboard entry with the current date and time
        LeaderboardEntry newEntry = new LeaderboardEntry(score, System.DateTime.Now.ToString());

        // Add the new entry to the list of leaderboard entries
        leaderboardEntries.Add(newEntry);

        // Sort the leaderboard entries by score (descending)
        leaderboardEntries.Sort((x, y) => y.score.CompareTo(x.score));

        // Remove any entries beyond the top 10
        if (leaderboardEntries.Count > 10)
        {
            leaderboardEntries.RemoveRange(10, leaderboardEntries.Count - 10);
        }

        // Save the updated leaderboard entries to the JSON file
        SaveLeaderboardEntries();
    }

    public List<LeaderboardEntry> GetTopScores()
    {
        // Return the top 10 leaderboard entries
        return leaderboardEntries.GetRange(0, Mathf.Min(10, leaderboardEntries.Count));
    }
}

[System.Serializable]
public class LeaderboardEntry
{
    public int score;
    public string dateTime;

    public LeaderboardEntry(int score, string dateTime)
    {
        this.score = score;
        this.dateTime = dateTime;
    }
}

