using UnityEngine;
using TMPro;

public class LeaderboardScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inputScore;
    [SerializeField]
    private TMP_InputField inputName;
    [SerializeField]
    private Leaderboard leaderboard;

    public async void SubmitScore()
    {
        if (leaderboard == null)
        {
            Debug.LogError("Leaderboard reference is not set");
            return;
        }

        if (string.IsNullOrEmpty(inputName.text))
        {
            Debug.LogError("Player name cannot be empty");
            return;
        }

        if (int.TryParse(inputScore.text.TrimEnd('m'), out int score)) // Remove 'm' if present
        {
            await leaderboard.SetLeaderboardEntry(inputName.text, score);
            Debug.Log($"Score submission initiated for player {inputName.text} with score {score}");
        }
        else
        {
            Debug.LogError("Invalid score input");
        }
    }
}