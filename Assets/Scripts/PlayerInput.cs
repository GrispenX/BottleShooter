using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static Action<int> OnShoot; // lane index

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q Pressed");
            OnShoot?.Invoke(0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W Pressed");
            OnShoot?.Invoke(1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Pressed");
            OnShoot?.Invoke(2);
        }
    }
}