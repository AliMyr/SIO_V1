using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private int sessionTimeMinutes = 15;
    [SerializeField] private float timeBetweenEnemySpawn = 1.5f;
    [SerializeField] private float minSpawnOffset = 7;
    [SerializeField] private float maxSpawnOffset = 18;

    public int SessionTimeMinutes { get { return sessionTimeMinutes; } }
    public int SessionTimeSeconds { get { return sessionTimeMinutes * 60; } }
    public float TimeBetweenEnemySpawn { get { return timeBetweenEnemySpawn; } }
    public float MinSpawnOffset { get { return minSpawnOffset; } }
    public float MaxSpawnOffset { get { return maxSpawnOffset; } }
}
