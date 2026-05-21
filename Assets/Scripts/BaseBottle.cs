using UnityEngine;

public abstract class BaseBottle : MonoBehaviour
{
    public float StartTime { get; private set; }

    public void Init(float startTime)
    {
        StartTime = startTime;
    }

    public abstract bool Hit();

    public abstract void End();
}
