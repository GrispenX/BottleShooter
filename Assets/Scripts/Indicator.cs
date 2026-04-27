using UnityEngine;

public class Indicator : MonoBehaviour
{
    public float duration = 0.5f;
    public LevelTimeline timeline;
    private float lastChangeTime = 0f;

    public void SetColor(Color color)
    {
        lastChangeTime = timeline.CurrentTime;
        GetComponent<Renderer>().material.color = color;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeline.CurrentTime > lastChangeTime + duration)
        {
            lastChangeTime = timeline.CurrentTime;
            GetComponent<Renderer>().material.color = Color.gray;
        }
    }
}
