using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform hitPoint;
    public Transform endPoint;

    private Queue<Bottle> bottles = new Queue<Bottle>();

    public void AddBottle(Bottle bottle)
    {
        bottles.Enqueue(bottle);
    }

    public void RemoveBottle(Bottle bottle)
    {
        if(bottles.Count > 0 && bottles.Peek() == bottle)
        {
            bottles.Dequeue();
            Destroy(bottle.gameObject);
        }
    }

    public Bottle Peek()
    {
        return bottles.Count > 0 ? bottles.Peek() : null;
    }

    public bool Hit(float hitWindow)
    {
        if(bottles.Count == 0) return false;
        Bottle bottle = bottles.Peek();
        if(bottle == null) return false;
        return bottle.Hit(hitWindow);
    }

    public Vector3 GetPosition(float progress)
    {
        return Vector3.Lerp(spawnPoint.position, endPoint.position, progress);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
