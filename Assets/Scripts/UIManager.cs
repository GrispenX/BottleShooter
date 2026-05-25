using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text timeText;
    public TMP_Text scoreText;

    void Update()
    {
        healthText.text = GameManager.instance.healthCounter.Health.ToString() + " HP";
        timeText.text = GameManager.instance.timeline.CurrentTime.ToString("#.## s");
        scoreText.text = Math.Round(GameManager.instance.scoreCounter.Score).ToString() + " pts";
    }
}