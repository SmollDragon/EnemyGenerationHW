using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawners;
    [SerializeField] private bool _isCoroutineWork;

    private float _spawnInterval = 2f;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnInterval);

        while (_isCoroutineWork)
        {
            yield return wait;
            ChoseSpawner();
        }
    }

    private void ChoseSpawner()
    {
        int chosenSpawner = Random.Range(0, _spawners.Length);
        _spawners[chosenSpawner].SpawnEnemy();
    }
}