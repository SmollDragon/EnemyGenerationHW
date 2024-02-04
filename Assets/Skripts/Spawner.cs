using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Vector3 _direction;

    private Transform _spawnPoint;

    private void Awake()
    {
        _spawnPoint = transform;
    }

    public void SpawnEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
        enemy.SetDirection(_direction);
    }
}
