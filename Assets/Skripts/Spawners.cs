using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    private Spawner[] spawners;
    private float _spawnInterval = 2f;

    private void Awake()
    {
        spawners = FindObjectsOfType<Spawner>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemyFromRandomSpawner), _spawnInterval, _spawnInterval);
    }

    private void SpawnEnemyFromRandomSpawner()
    {
        int randomIndex = Random.Range(0, spawners.Length);
        spawners[randomIndex].SpawnEnemy();
    }
}
