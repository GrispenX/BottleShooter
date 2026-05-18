using UnityEngine;

public class GameStart : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Debug.Log($"Loading scene: {sceneName}");
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void LoadGameScene()
    {
        LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game.");
        Application.Quit();
    }
}

