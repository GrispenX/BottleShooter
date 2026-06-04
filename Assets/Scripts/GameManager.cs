using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ScoreCounter scoreCounter;
    public HealthCounter healthCounter;
    public LevelMusicController musicController;
    public BottleSpawnSystem bottleSpawner;
    public LevelData levelData;
    public List<Lane> lanes;

    public GameObject pauseMenuOverlay;
    public GameObject gameOverOverlay;

    public bool IsPaused { get; private set; }

    public void SwitchPause()
    {
        if(IsPaused)
        {
            musicController.UnpauseMusic();
        }
        else
        {
            musicController.PauseMusic();
        }
        pauseMenuOverlay.SetActive(!IsPaused);
        IsPaused = !IsPaused;
    }

    public void RestartLevel()
    {
        gameOverOverlay.SetActive(false);
        musicController.StopMusic();
        musicController.StartMusic();
        scoreCounter.ResetCombo();
        scoreCounter.ResetScore();
        healthCounter.Reset();
        foreach(Lane lane in lanes)
        {
            lane.ClearBottles();
        }
        bottleSpawner.levelData = levelData;
        bottleSpawner.Reset();
        musicController.audioClip = levelData.audioClip;
    }

    public void EndLevel()
    {
        musicController.StopMusic();
        gameOverOverlay.SetActive(true);
    }

    public void LeaveLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}