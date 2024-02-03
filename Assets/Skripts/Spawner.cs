using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _enemy;
    [SerializeField] private Vector3 _direction;

    private Transform _spawnPoint;

    private void Awake()
    {
        _spawnPoint = transform;
    }

    public void SpawnEnemy()
    {
        Transform enemyCreator = Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
        Enemy enemy = enemyCreator.gameObject.AddComponent<Enemy>();
        enemy.SetDirection(_direction);
    }
}
