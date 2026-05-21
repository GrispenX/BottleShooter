using System;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform hitPoint;
    public Transform endPoint;
    public float travelTime = 2.0f;
    public LevelTimeline timeline;
    private Queue<BaseBottle> bottles = new Queue<BaseBottle>();

    public void AddBottle(BaseBottle bottle)
    {
        bottles.Enqueue(bottle);
    }

    public void Hit()
    {
        if(bottles.Count == 0) return;
        BaseBottle bottle = bottles.Peek();
        float hit_point_ratio = Vector3.Distance(spawnPoint.position, hitPoint.position) / Vector3.Distance(spawnPoint.position, endPoint.position);
        float perfect_hit_time = bottle.StartTime + travelTime * hit_point_ratio;
        float error = Math.Abs(perfect_hit_time - timeline.CurrentTime);
        float hit_window = (1.0f - hit_point_ratio) * travelTime;
        if(error <= hit_window)
        {
            if(bottle.Hit())
            {
                bottles.Dequeue();
                Destroy(bottle.gameObject);
            }   
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bottles.Count == 0) return;
        foreach(BaseBottle bottle in bottles)
        {
            float a = bottle.StartTime;
            a = timeline.CurrentTime;
            a = travelTime;
            float progress = (timeline.CurrentTime - bottle.StartTime) / travelTime;
            bottle.transform.position = Vector3.Lerp(spawnPoint.position, endPoint.position, progress);
        }
        if(bottles.Peek().StartTime + travelTime <= timeline.CurrentTime)
        {
            BaseBottle bottle = bottles.Dequeue();
            bottle.End();
            Destroy(bottle.gameObject);
        }
    }

    void OnDrawGizmos()
    {
        if (spawnPoint && hitPoint && endPoint)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(spawnPoint.position, hitPoint.position);

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(hitPoint.position, endPoint.position);
        }
    }
}
