using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private string url = "https://merkag.co.jp/";

    public void OnPlayButtonClicked()
    {
        SceneLoader.Instance.LoadPlayScene();
    }

    public void OnRankingButtonClicked()
    {
        SceneLoader.Instance.LoadRankingScene();
    }

    public void OnItemListButtonClicked()
    {
        SceneLoader.Instance.LoadItemListScene();
    }

    public void OnBackToMainMenuButtonClicked()
    {
        SceneLoader.Instance.LoadMainMenu();
    }

    public void OnCollaborationButtonClicked()
    {
        Application.OpenURL(url);
    }
}