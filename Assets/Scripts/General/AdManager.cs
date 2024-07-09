using UnityEngine;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    public Image adImage;
    public Button closeButton;
    private SceneLoader sceneLoader;

    void Start()
    {
        closeButton.onClick.AddListener(CloseAd);
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CloseAd()
    {
        gameObject.SetActive(false);
        if (sceneLoader != null)
        {
            sceneLoader.SendMessage("AdClosed");
        }
    }

    void AdAction()
    {
        Debug.Log("Ad action performed");
        // ここに広告のアクション（例：リンクを開く、ゲーム内報酬を与えるなど）を実装
    }

    public void ShowAd()
    {
        gameObject.SetActive(true);
    }
}