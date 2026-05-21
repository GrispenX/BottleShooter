using System.Collections.Generic;
using UnityEngine;

public class HitSystem : MonoBehaviour
{
    void OnEnable()
    {
        PlayerInput.OnShoot += HandleShoot;
    }

    void OnDisable()
    {
        PlayerInput.OnShoot -= HandleShoot;
    }

    void HandleShoot(int laneIndex)
    {
        GameManager.instance.lanes[laneIndex].Hit();
    }
}