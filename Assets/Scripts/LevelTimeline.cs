using UnityEngine;

public class LevelTimeline : MonoBehaviour
{
    public float CurrentTime { get; private set; }

    public void ResetTime()
    {
        CurrentTime = 0f;
    }

    void Update()
    {
        CurrentTime += Time.deltaTime;
    }
}
