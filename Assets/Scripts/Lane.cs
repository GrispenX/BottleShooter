using System;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform hitPoint;
    public Transform endPoint;
    [Range(1.0f, 3.0f)] public float travelTime = 2.0f;
    private Queue<BaseBottle> bottles = new Queue<BaseBottle>();

    public void AddBottle(BaseBottle bottle)
    {
        bottles.Enqueue(bottle);
    }

    public void ClearBottles()
    {
        while(bottles.Count >= 1)
        {
            Destroy(bottles.Dequeue().gameObject);
        }
    }

    public void Hit()
    {
        if(bottles.Count == 0) return;
        BaseBottle bottle = bottles.Peek();
        float hit_point_ratio = Vector3.Distance(spawnPoint.position, hitPoint.position) / Vector3.Distance(spawnPoint.position, endPoint.position);
        float perfect_hit_time = bottle.StartTime + travelTime * hit_point_ratio;
        float error = Math.Abs(perfect_hit_time - (float)GameManager.instance.musicController.CurrentTime);
        float hit_window = (1.0f - hit_point_ratio) * travelTime;
        if(error <= hit_window)
        {
            float accuracy = 1.0f - (error / hit_window);
            if(bottle.Hit(accuracy))
            {
                bottle = bottles.Dequeue();
                Destroy(bottle.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(bottles.Count == 0) return;
        foreach(BaseBottle bottle in bottles)
        {
            float progress = ((float)GameManager.instance.musicController.CurrentTime - bottle.StartTime) / travelTime;
            bottle.transform.position = Vector3.Lerp(spawnPoint.position, endPoint.position, progress);
        }
        if(bottles.Peek().StartTime + travelTime <= GameManager.instance.musicController.CurrentTime)
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
