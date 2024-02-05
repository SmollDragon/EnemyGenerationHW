using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Target[] _targets;

    private Transform _spawnPoint;

    private void Awake()
    {
        _spawnPoint = transform;
    }

    public void SpawnEnemy()
    {
        int chosenTarget = Random.Range(0, _targets.Length);
        Enemy enemy = Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
        enemy.SetTarget(_targets[chosenTarget]);            
    }
}
