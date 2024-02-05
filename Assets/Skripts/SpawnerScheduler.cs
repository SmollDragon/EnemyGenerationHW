using Unity.VisualScripting;
using UnityEngine;

public class SpawnerScheduler : MonoBehaviour
{
    private Spawner[] _spawners;
    private float _spawnInterval = 2f;

    private void Awake()
    {
        _spawners = FindObjectsOfType<Spawner>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), _spawnInterval, _spawnInterval);
    }

    private void SpawnEnemy()
    {
        int chosenSpawner = Random.Range(0, _spawners.Length);        
        _spawners[chosenSpawner].SpawnEnemy();       
    }
}
