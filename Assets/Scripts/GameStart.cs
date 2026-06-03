using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [Header("UI Панелі")]
    public GameObject mainMenuPanel;    // Головне вікно (де кнопки Continue, Settings, Quit)
    public GameObject levelSelectPanel;  // Нове вікно вибору рівнів
    public GameObject settingsPanel;     // Панель налаштувань

    private void Start()
    {
        // При запуску гри активне тільки головне меню, все інше ховаємо
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        if (levelSelectPanel != null) levelSelectPanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);
    }


    public void OpenLevelSelect()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (levelSelectPanel != null) levelSelectPanel.SetActive(true);
    }

    // Викликаємо при натисканні на кнопку "Back" у вікні рівнів
    public void CloseLevelSelect()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        if (levelSelectPanel != null) levelSelectPanel.SetActive(false);
    }

    // --- Завантаження Сцен ---

    // Цей метод вішаємо на кнопки конкретних рівнів і пишемо туди назву сцени
    public void LoadScene(string sceneName)
    {
        Debug.Log($"Loading scene: {sceneName}");
        SceneManager.LoadScene(sceneName);
    }



    // --- Логіка Налаштувань ---

    public void OpenSettings()
    {
        if (settingsPanel != null) settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        if (settingsPanel != null) settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game.");
        Application.Quit();
    }
}