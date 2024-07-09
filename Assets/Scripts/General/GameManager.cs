using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerData
{
    public int currentLife;
    public int maxLife;

    public bool isProtected { get; set; }
    public string condomeUIName = "CondomeUI";

    public PlayerData(int maxLife)
    {
        this.maxLife = maxLife;
        currentLife = maxLife;
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject canvas;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Text gameUIScoreText; // 追加：ゲーム中のスコアテキスト
    private GameObject gameOverUI;
    public PlayerData playerData;
    public int initialMaxLife = 3;
    public GameObject playerPrefab;
    public Canvas uiCanvasPrefab;
    public float playerSpawnHeight = 2f; // インスペクターで調整可能なプレイヤーの生成の高さ
    private Canvas uiCanvas;
    private GameObject playerObject;
    private ScoreManager scoreManager;

    private bool isGameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if (playerData == null)
        {
            InitializePlayerData();
        }

        InitializeUI();
        InitializePlayer();

        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void InitializeUI()
    {
        Canvas existingCanvas = FindObjectOfType<Canvas>();
        if (existingCanvas == null)
        {
            if (uiCanvasPrefab != null)
            {
                uiCanvas = Instantiate(uiCanvasPrefab);
                DontDestroyOnLoad(uiCanvas.gameObject);
            }
            else
            {
                Debug.LogError("UI Canvas Prefab is not assigned!");
            }
        }
        else
        {
            uiCanvas = existingCanvas;
        }

        Transform[] transforms = uiCanvas.GetComponentsInChildren<Transform>(true);
        foreach (Transform transform in transforms)
        {
            if (transform.CompareTag("GameOverUI"))
            {
                gameOverUI = transform.gameObject;
                break;
            }
            else if (transform.CompareTag("GameUIScore")) // 追加：ゲーム中のスコアテキストを探す
            {
                gameUIScoreText = transform.GetComponent<Text>();
            }
        }
    }

    private void InitializePlayer()
    {
        if (playerPrefab != null)
        {
            Vector3 spawnPosition = new Vector3(0f, playerSpawnHeight, 0f);
            playerObject = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
            DontDestroyOnLoad(playerObject);
        }
        else
        {
            Debug.LogError("Player prefab is not assigned!");
        }
    }

    private void Start()
    {
        if (playerData == null)
        {
            InitializePlayerData();
        }

        canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            Transform gameOverUITransform = canvas.transform.Find("GameOverUI");
            if (gameOverUITransform != null)
            {
                gameOverUI = gameOverUITransform.gameObject;
                gameOverUI.SetActive(false);
            }
            else
            {
                Debug.Log("GameOverUI not found in Canvas");
            }
        }
        else
        {
            Debug.Log("Canvas not found in the scene");
        }
    }

    private void InitializePlayerData()
    {
        playerData = new PlayerData(initialMaxLife);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameOverUI = FindInActiveObjectByName("GameOverUI");
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
        else
        {
            Debug.LogError("GameOverUI not found!");
        }

        if (playerData == null)
        {
            InitializePlayerData();
        }
        playerData.currentLife = playerData.maxLife;
        isGameOver = false;
    }

    private void Update()
    {
        if (playerData != null && playerData.currentLife <= 0 && isGameOver == false)
        {
            Debug.Log(playerData.currentLife + " life left. Game Over!");
            GameOver();
        }
    }

    public void GameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            Debug.Log("Game Over UI activated: " + gameOverUI.activeSelf);
            DisplayFinalScore();

            // ゲーム中のスコアテキストを非表示にする
            if (gameUIScoreText != null)
            {
                gameUIScoreText.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("Game UI Score Text is null in GameOver!");
            }
        }
        else
        {
            Debug.LogError("GameOverUI not found!");
        }
        isGameOver = true;

        // Ensure high score is saved
        if (scoreManager != null)
        {
            scoreManager.UpdateHighScore(scoreManager.GetHighScore());
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        ResetUI();
        if (SceneLoader.Instance != null)
        {
            SceneLoader.Instance.LoadPlayScene();
        }
        else
        {
            Debug.LogError("SceneLoader.Instance is null!");
        }
    }


    private GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    private void DisplayFinalScore()
    {
        if (scoreText != null)
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                float finalScore = scoreManager.GetCurrentScore();
                scoreText.text = finalScore.ToString("F0") + "m";
            }
            else
            {
                Debug.LogError("ScoreManager not found!");
            }
        }
        else
        {
            Debug.LogError("Score Text not found in GameOverUI!");
        }
    }

    // ゲームを再開する際にゲーム中のスコアテキストを再表示するメソッド
    public void ResetUI()
    {
        if (gameUIScoreText != null)
        {
            gameUIScoreText.gameObject.SetActive(true);
        }
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }
}