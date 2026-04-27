using UnityEngine;
using System.Linq;

public class HitSystem : MonoBehaviour
{
    public LevelTimeline timeline;
    public Lane[] lanes;
    public float hitWindow = 1f;

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
        lane.Hit(hitWindow);
    }
}