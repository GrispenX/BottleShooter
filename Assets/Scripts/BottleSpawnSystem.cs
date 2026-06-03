using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

internal class SimplifiedBottleData
{
    public float spawnTime;
    public BottleType bottleType;
}

internal class SimplifiedLaneData
{
    public Queue<SimplifiedBottleData> bottles = new Queue<SimplifiedBottleData>();
}

public class BottleSpawnSystem : MonoBehaviour
{
    public LevelData levelData;
    private List<SimplifiedLaneData> simplifiedLanes;
    public DefaultBottle defaultBottlePrefab;
    public FatBottle fatBottlePrefab;
    public AcidBottle acidBottlePrefab;
    public HealBottle healBottlePrefab;

    public void Reset()
    {
        simplifiedLanes = new List<SimplifiedLaneData>();
        for(int lane_idx = 0; lane_idx < levelData.lanes.Count; lane_idx++)
        {
            SimplifiedLaneData simplified_lane_data = new SimplifiedLaneData();
            float spawn_time = 0;
            LaneData lane_data = levelData.lanes[lane_idx];
            for(int wave_idx = 0; wave_idx < lane_data.waves.Count; wave_idx++)
            {
                WaveData wave_data = lane_data.waves[wave_idx];
                spawn_time += wave_data.delay;
                for(int group_idx = 0; group_idx < wave_data.groups.Count; group_idx++)
                {
                    GroupData group_data = wave_data.groups[group_idx];
                    spawn_time += group_data.delay;
                    for(int bottle_idx = 0; bottle_idx < group_data.bottles.Count; bottle_idx++)
                    {
                        SimplifiedBottleData simplified_bottle_data = new SimplifiedBottleData();
                        BottleData bottle_data = group_data.bottles[bottle_idx];
                        spawn_time += bottle_data.delay;
                        simplified_bottle_data.spawnTime = spawn_time;
                        simplified_bottle_data.bottleType = bottle_data.bottleType;
                        simplified_lane_data.bottles.Enqueue(simplified_bottle_data);
                    }
                }
            }
            simplifiedLanes.Add(simplified_lane_data);
        }
    }

    void Start()
    {
        Reset();
    }

    void Update()
    {
        for(int lane_idx = 0; lane_idx < simplifiedLanes.Count; lane_idx++)
        {
            SimplifiedLaneData lane_data = simplifiedLanes[lane_idx];
            while(lane_data.bottles.Count > 0 && lane_data.bottles.Peek().spawnTime <= GameManager.instance.musicController.CurrentTime)
            {
                SimplifiedBottleData bottle_data = lane_data.bottles.Dequeue();
                Lane lane = GameManager.instance.lanes[lane_idx];
                BaseBottle bottle = bottle_data.bottleType switch
                {
                    BottleType.Default => Instantiate(defaultBottlePrefab, lane.spawnPoint.position, Quaternion.identity),
                    BottleType.Fat     => Instantiate(fatBottlePrefab, lane.spawnPoint.position, Quaternion.identity),
                    BottleType.Acid    => Instantiate(acidBottlePrefab, lane.spawnPoint.position, Quaternion.identity),
                    BottleType.Heal    => Instantiate(healBottlePrefab, lane.spawnPoint.position, Quaternion.identity),
                    _                  => throw new Exception("Fuck it")
                };
                bottle.Init(bottle_data.spawnTime);
                lane.AddBottle(bottle);
            }
        }
    }
}
