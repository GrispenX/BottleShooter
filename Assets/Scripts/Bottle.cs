using Unity.VisualScripting;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    private float startTime;
    private float hitTime;
    private float endTime;
    private Lane lane;
    private LevelTimeline timeline;

    public void Init(float startTime, float hitTime, float endTime, Lane lane, LevelTimeline timeline)
    {
        this.startTime = startTime;
        this.hitTime = hitTime;
        this.endTime = endTime;
        this.lane = lane;
        this.timeline = timeline;
    }

    void Update()
    {
        float progress = (timeline.CurrentTime - startTime) / (endTime - startTime);

        transform.position = lane.GetPosition(progress);

        if(progress > 1.0f)
        {
            Debug.Log($"{startTime} {hitTime} {endTime} {timeline.CurrentTime} {progress} Destroying");
            Destroy(gameObject);
        }
    }
}
