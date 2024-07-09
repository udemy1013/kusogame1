using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[System.Serializable]
public class SceneReference
{
    public string sceneName;
}

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    [SerializeField] private SceneReference mainMenuScene;
    [SerializeField] private SceneReference playScene;
    [SerializeField] private SceneReference rankingScene;
    [SerializeField] private SceneReference itemListScene;

    [SerializeField] private AdManager adManager;

    private string nextSceneName;
    private bool isWaitingForAdClose = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (adManager != null && adManager.closeButton != null)
        {
            adManager.closeButton.onClick.AddListener(AdClosed);
        }
    }

    public void LoadMainMenu()
    {
        LoadSceneWithPossibleAd(mainMenuScene.sceneName);
    }

    public void LoadPlayScene()
    {
        LoadSceneWithPossibleAd(playScene.sceneName);
    }

    public void LoadRankingScene()
    {
        LoadSceneWithPossibleAd(rankingScene.sceneName);
    }

    public void LoadItemListScene()
    {
        LoadSceneWithPossibleAd(itemListScene.sceneName);
    }

    private void LoadSceneWithPossibleAd(string sceneName)
    {
        if (Random.value < 0.00f && adManager != null)
        {
            Debug.Log("Showing ad before loading scene: " + sceneName);
            nextSceneName = sceneName;
            ShowAd();
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void LoadPlaySceneWithAd()
    {
        StartCoroutine(LoadPlaySceneWithAdCoroutine());
    }

    private IEnumerator LoadPlaySceneWithAdCoroutine()
    {
        // プレイシーンを非同期で読み込む
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(playScene.sceneName);

        // シーンの読み込みを完了させるが、アクティブにはしない
        asyncLoad.allowSceneActivation = false;

        // シーンの読み込みが完了するまで待機
        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }

        // 広告を表示
        if (adManager != null)
        {
            adManager.ShowAd();
            isWaitingForAdClose = true;

            // 広告が閉じられるまで待機
            while (isWaitingForAdClose)
            {
                yield return null;
            }
        }

        // シーンをアクティブにする
        asyncLoad.allowSceneActivation = true;
    }


    private void ShowAd()
    {
        adManager.ShowAd();
        isWaitingForAdClose = true;
    }

    private void AdClosed()
    {
        if (isWaitingForAdClose)
        {
            isWaitingForAdClose = false;
            SceneManager.LoadScene(nextSceneName);
        }
    }

    public void StartGame()
    {
        LoadPlayScene();
    }
}