using System.Collections.Generic;
using UnityEngine;

public class HitSystem : MonoBehaviour
{
    public List<Lane> lanes;

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
        Lane lane = lanes[laneIndex];
        lane.Hit();
    }
}