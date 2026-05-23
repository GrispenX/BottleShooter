using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static Action<int> OnShoot; // lane index

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnShoot?.Invoke(0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            OnShoot?.Invoke(1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            OnShoot?.Invoke(2);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            GameManager.instance.RestartGame();
        }
    }
}