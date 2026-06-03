using System.Collections.Generic;
using UnityEngine;

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