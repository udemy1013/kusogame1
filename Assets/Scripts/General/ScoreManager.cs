using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    private Text scoreText;
    private Player player;
    private float highestPosition = 0f;
    private float baseScore = 0f;

    public float doubleUpDuration = 5f;
    public bool isDoubleUpActive = false;
    private float doubleUpScore = 0f;

    public string doubleUpUIName = "DoubleUpUI";

    private GameObject doubleUpUI;

    private const string HighScoreKey = "HighScore";

    private void Awake()
    {
        InitializeComponents();
    }

    private void OnEnable()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // CanvasからscoreTextを取得
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            scoreText = canvas.GetComponentInChildren<Text>();
        }
        else
        {
            Debug.LogError("Canvas not found in the scene");
        }

        player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("Player not found in the scene");
        }

        // すべての Transform コンポーネントを検索
        Transform[] allTransforms = GameObject.FindObjectsOfType<Transform>();
        foreach (Transform t in allTransforms)
        {
            if (t.name == doubleUpUIName)
            {
                doubleUpUI = t.gameObject;
                break;
            }
        }

        if (doubleUpUI != null)
        {
            doubleUpUI.SetActive(false);
        }
        else
        {
            Debug.LogWarning("DoubleUp UI not found! Make sure an object named '" + doubleUpUIName + "' exists in the scene.");
        }
    }

    private void Update()
    {
        if (player == null || scoreText == null)
        {
            return; // 必要なコンポーネントが見つからない場合は更新をスキップ
        }

        // プレイヤーの現在のY座標を取得
        float currentPosition = player.transform.position.y;

        // 基本スコアとDoubleUpスコアを更新
        if (currentPosition > highestPosition)
        {
            float delta = currentPosition - highestPosition;
            baseScore += delta;
            if (isDoubleUpActive)
            {
                doubleUpScore += delta * 2f;
            }
            highestPosition = currentPosition;
        }

        // スコアテキストを更新
        float totalScore = baseScore + doubleUpScore;
        float displayScore = Mathf.FloorToInt(totalScore * 10f * 1.5f);
        scoreText.text = $"{displayScore}m";

        // Update high score
        UpdateHighScore(Mathf.FloorToInt(displayScore));
    }

    public void UpdateHighScore(int currentScore)
    {
        int highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, currentScore);
            PlayerPrefs.Save();
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    // DoubleUpの効果を有効にする
    public void ActivateDoubleUp()
    {
        if (!isDoubleUpActive)
        {
            Debug.Log("DoubleUp activated!");
            isDoubleUpActive = true;
            StartCoroutine(DeactivateDoubleUpAfterDelay());

            if (doubleUpUI != null)
            {
                doubleUpUI.SetActive(true); // DoubleUp UIを表示します
                StartCoroutine(DeactivateDoubleUpAfterDuration(doubleUpDuration));
            }
        }

    }



    // DoubleUpの効果をdoubleUpDuration後に無効にする
    private IEnumerator DeactivateDoubleUpAfterDelay()
    {
        yield return new WaitForSeconds(doubleUpDuration);

        DeactivateDoubleUp();
    }

    // DoubleUpの効果を無効にする
    private void DeactivateDoubleUp()
    {
        isDoubleUpActive = false;
        Debug.Log("DoubleUp deactivated! DoubleUp score: " + doubleUpScore);
        baseScore += doubleUpScore; // doubleUpScoreをbaseScoreに加算
        doubleUpScore = 0f; // doubleUpScoreをリセット
    }

    private IEnumerator DeactivateDoubleUpAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        if (doubleUpUI != null)
        {
            doubleUpUI.SetActive(false); // DoubleUp UIを非表示にします
        }
    }

    // スコアを加算する
    public void AddScore(float scoreToAdd)
    {
        float scoreInUnits = scoreToAdd / 10f / 1.5f; // ここを追加
        baseScore += scoreInUnits;
    }

    // 現在のスコアを取得するメソッドを追加
    public float GetCurrentScore()
    {
        float totalScore = baseScore + doubleUpScore;
        return Mathf.FloorToInt(totalScore * 10f * 1.5f);
    }
}