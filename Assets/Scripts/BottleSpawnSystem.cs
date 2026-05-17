using UnityEngine;

public class BottleSpawnSystem : MonoBehaviour
{
    public LevelData levelData;
    public LevelTimeline timeline;

    public Bottle bottlePrefab;
    public Lane[] lanes;

    public float travelTime = 2f;
    private int index = 0;
    private float startTimeOffset;
    private float endTimeOffset;

    void Start()
    {
        index = 0;
        timeline.ResetTime();
        Lane lane = lanes[0];
        Vector3 start = lane.spawnPoint.position;
        Vector3 hit = lane.hitPoint.position;
        Vector3 end = lane.endPoint.position;
        startTimeOffset = Vector3.Distance(start, hit) / Vector3.Distance(start, end) * travelTime;
        endTimeOffset = Vector3.Distance(hit, end) / Vector3.Distance(start, end) * travelTime;
    }

    void Update()
    {
        while (index < levelData.notes.Count && levelData.notes[index].time <= timeline.CurrentTime + startTimeOffset)
        {
            Spawn(levelData.notes[index]);
            index++;
        }
    }

    void Spawn(Note note)
    {
        Lane lane = lanes[note.lane];
        Bottle bottle = Instantiate(bottlePrefab, lane.spawnPoint.position, Quaternion.identity);
        bottle.Init(note.time - startTimeOffset, note.time, note.time + endTimeOffset, lane, timeline);
    }
}
