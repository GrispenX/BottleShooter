using System;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int Health { get; private set; } = 100;

    public void Reset()
    {
        Health = 100;
    }

    public void AddHealth(int amount)
    {
        if(amount <= 0) return;
        Health = Math.Min(Health + amount, 100);
    }

    public void RemoveHealth(int amount)
    {
        if(amount <= 0) return;
        Health = Math.Max(Health - amount, 0);
        if(Health == 0) GameManager.instance.RestartGame();
    }
}
