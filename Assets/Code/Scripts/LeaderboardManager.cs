using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeaderboardManager : MonoBehaviour
{
    private string filePath;
    private LeaderboardEntryList leaderboard;
    private List<LeaderboardEntry> leaderboardEntries;

    private void Awake()
    {
        // Set the file path for the leaderboard JSON file
        filePath = Application.persistentDataPath + "/leaderboard.json";
        Debug.Log(Application.persistentDataPath);

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
            leaderboard = JsonUtility.FromJson<LeaderboardEntryList>(json);
            Debug.Log("Found old file, using : " + leaderboard.leaderboardEntries.Count.ToString());
        }
        else
        {
            Debug.Log("Creating empty, file does not exist");
            // If the file does not exist, create a new empty list of leaderboard entries
            leaderboard = new LeaderboardEntryList();
            leaderboard.leaderboardEntries = new List<LeaderboardEntry>();
        }
    }

    private void SaveLeaderboardEntries()
    {
        // Serialize the leaderboard entries to JSON
        string json = JsonUtility.ToJson(leaderboard);

        // Write the JSON data to the file
        File.WriteAllText(filePath, json);
        Debug.Log("Saved to file : " + json);
    }

    public void AddScore(int score)
    {
        // Create a new leaderboard entry with the current date and time
        LeaderboardEntry newEntry = new LeaderboardEntry(score, System.DateTime.Now.ToString());

        // Add the new entry to the list of leaderboard entries
        leaderboard.leaderboardEntries.Add(newEntry);

        // Sort the leaderboard entries by score (descending)
        leaderboard.leaderboardEntries.Sort((x, y) => y.score.CompareTo(x.score));

        // Remove any entries beyond the top 10
        if (leaderboard.leaderboardEntries.Count > 10)
        {
            leaderboard.leaderboardEntries.RemoveRange(10, leaderboardEntries.Count - 10);
        }

        Debug.Log("After addition contains : " +  leaderboard.leaderboardEntries.Count.ToString());
        // Save the updated leaderboard entries to the JSON file
        SaveLeaderboardEntries();
    }

    public List<LeaderboardEntry> GetTopScores()
    {
        // Return the top 10 leaderboard entries
        return leaderboard.leaderboardEntries.GetRange(0, Mathf.Min(5, leaderboard.leaderboardEntries.Count));
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

[System.Serializable]
public class LeaderboardEntryList
{
    public List<LeaderboardEntry> leaderboardEntries;

}