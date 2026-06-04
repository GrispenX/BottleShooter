using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Combo { get; private set; }
    public float Score { get; private set; }

    public void ResetCombo()
    {
        Combo = 0;
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public void AddScore(float bottle_base, float accuracy)
    {
        Score += bottle_base + 0.1f * bottle_base * Math.Min(Combo, 10);
        Combo += 1;
    }
}