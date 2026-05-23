using System;
using System.Collections.Generic;
using UnityEngine;

public enum BottleType
{
    Default,
    Fat,
    Acid,
    Heal
}

[Serializable]
public class BottleData
{
    public float delay;
    public BottleType bottleType;
}

[Serializable]
public class GroupData
{
    public float delay;
    public List<BottleData> bottles;
}

[Serializable]
public class WaveData
{
    public float delay;
    public List<GroupData> groups;
}

[Serializable]
public class LaneData
{
    public List<WaveData> waves;
}

[CreateAssetMenu(menuName = "Game/Level Data")]
public class LevelData : ScriptableObject
{
    public List<LaneData> lanes;
}