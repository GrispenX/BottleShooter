using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.iOS;

public class Bottle : MonoBehaviour
{
    public float StartTime { get; private set; }
    public float HitTime { get; private set; }
    public float EndTime { get; private set; }
    public Lane Lane { get; private set; }
    public Indicator Indicator { get; private set; }
    private LevelTimeline timeline;

    public void Init(float startTime, float hitTime, float endTime, Lane lane, Indicator indicator, LevelTimeline timeline)
    {
        StartTime = startTime;
        HitTime = hitTime;
        EndTime = endTime;
        Lane = lane;
        Indicator = indicator;
        this.timeline = timeline;
    }

    void Update()
    {
        float progress = (timeline.CurrentTime - StartTime) / (EndTime - StartTime);

        transform.position = Lane.GetPosition(progress);

        if(progress > 1.0f)
        {
            Indicator.SetColor(Color.red);
            Lane.RemoveBottle(this);
        }
    }

    public bool Hit(float hitWindow)
    {
        float error = Mathf.Abs(timeline.CurrentTime - HitTime);
        if(error <= hitWindow)
        {
            Debug.Log("Bottle destroyed");
            Indicator.SetColor(Color.green);
            Lane.RemoveBottle(this);
            return true;
        }
        return false;
    }
}
