using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] Vector3 _direction;

    private Transform _spawnPoint;

    private void Awake()
    {
        _spawnPoint = transform;
    }

    public void SpawnEnemy()
    {
        GameObject enemyObject = Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
        Enemy enemy = enemyObject.AddComponent<Enemy>();
        
        enemy.ChangeDirection(_direction);
    }  
}
