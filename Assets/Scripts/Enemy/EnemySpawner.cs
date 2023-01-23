using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private List<EnemyWave> _waves;

    private EnemyWave _currentWave;
    private int _currentWaveIndex = 0;

    private void OnEnable()
    {
        _currentWave = _waves[_currentWaveIndex];
    }

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        foreach(var enemy in _currentWave.Enemies)
        {
            var newEnemy = Instantiate(enemy, (Vector2)_currentWave.SpawnPoints[Random.Range(0, _currentWave.SpawnPoints.Count)].position + Random.insideUnitCircle.normalized, Quaternion.identity);
            newEnemy.Init(_target);
            yield return new WaitForSeconds(Random.Range(0, _currentWave.MaxSpawnDelay));
        }

        _currentWaveIndex++;
    }
}

[System.Serializable]
public class EnemyWave
{
    public float MaxSpawnDelay; 
    public List<Enemy> Enemies;
    public List<Transform> SpawnPoints;
}
