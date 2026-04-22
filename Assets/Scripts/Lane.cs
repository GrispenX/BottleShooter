using System.Net;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform hitPoint;
    public Transform endPoint;

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
