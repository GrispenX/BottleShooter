using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ScoreCounter scoreCounter;
    public HealthCounter healthCounter;
    public LevelMusicController musicController;
    public BottleSpawnSystem bottleSpawner;
    public List<Lane> lanes;

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

    public void Pause()
    {
        musicController.PauseMusic();
    }

    public void Unpause()
    {
        musicController.UnpauseMusic();
    }

    void Start()
    {
        RestartGame();
    }

    public void RestartGame()
    {
        musicController.StopMusic();
        musicController.StartMusic();
        scoreCounter.ResetCombo();
        scoreCounter.ResetScore();
        healthCounter.Reset();
        foreach(Lane lane in lanes)
        {
            lane.ClearBottles();
        }
        bottleSpawner.Reset();
    }
}