using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Vector3 _direction;

    private Transform _spawnPoint;

    private void Awake()
    {
        _spawnPoint = transform;
    }

    public void SpawnEnemy()
    {
        GameObject enemyObject = Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
        Enemy enemy = enemyObject.AddComponent<Enemy>();        
        enemy.SetDirection(_direction);
    }  
}
