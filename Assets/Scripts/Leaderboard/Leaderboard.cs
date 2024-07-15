using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;
using System.Collections.Generic;
using TMPro;
using System.Threading.Tasks;


public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;
    [SerializeField] private string leaderboardId = "HighScore";
    [SerializeField] private TextMeshProUGUI highscoreText;
    private const string HighScoreKey = "HighScore";

    private void Start()
    {
        InitializeAndGetLeaderboard().LogExceptions();
    }

    private async Task InitializeAndGetLeaderboard()
    {
        await InitializeUnityServices();
        await GetLeaderboard();
        DisplayHighScore();
    }

    private void DisplayHighScore()
    {
        int highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (highscoreText != null)
        {
            highscoreText.text = $"{highScore}m";
        }
        else
        {
            Debug.LogWarning("Highscore TextMeshProUGUI is not assigned!");
        }
    }

    private async Task InitializeUnityServices()
    {
        try
        {
            await UnityServices.InitializeAsync();
            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }
            Debug.Log("Successfully signed in anonymously");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to initialize Unity Services: {e.Message}");
        }
    }

    public async Task GetLeaderboard()
    {
        try
        {
            var scores = await LeaderboardsService.Instance.GetScoresAsync(leaderboardId);

            int loopLength = Mathf.Min(scores.Results.Count, names.Count);
            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = TruncateName(scores.Results[i].PlayerName);
                this.scores[i].text = $"{scores.Results[i].Score}m"; // Added 'm' suffix here
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to get leaderboard: {e.Message}");
        }
    }

    private string TruncateName(string name)
    {
        return name.Length > 9 ? name.Substring(0, 9) + "..." : name;
    }

    public async Task SetLeaderboardEntry(string username, int score)
    {
        try
        {
            await AuthenticationService.Instance.UpdatePlayerNameAsync(username);
            await LeaderboardsService.Instance.AddPlayerScoreAsync(leaderboardId, score);
            Debug.Log($"Successfully added score for {username}: {score}");
            await GetLeaderboard();
            DisplayHighScore();
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to set leaderboard entry: {e.Message}");
        }
    }
}