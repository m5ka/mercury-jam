using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
public class SpawnManager : Singleton<SpawnManager>
{
    public int EnemyCount => _enemyCount;
    public int CombinedDifficulty => _combinedDifficulty;

    [BoxGroup("Enemies"), LabelText("Types")] public List<Enemy> enemyTypes;
    [BoxGroup("Enemies"), LabelText("Maximum number")] public int maxEnemies = 5;

    private readonly List<GameObject> _currentEnemies = new();
    private int _combinedDifficulty;
    private int _enemyCount;
    public int DefaultMaxEnemies => _defaultMaxEnemies;
    private int _defaultMaxEnemies;


    public void Start()
    {
        _defaultMaxEnemies = maxEnemies;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (_enemyCount < maxEnemies && _combinedDifficulty < WaveManager.Instance.WaveDifficulty)
            {
                Enemy chosenEnemy;
                do
                {
                    chosenEnemy = enemyTypes[Random.Range(0, enemyTypes.Count)];
                } while (_combinedDifficulty + chosenEnemy.difficulty > WaveManager.Instance.WaveDifficulty);
                if (Player.CurrentPlayer.CurrentHealth >0)
                {
                    var level = LevelManager.Instance.levels[LevelManager.Instance.CurrentLevelIndex];
                    var spawnPoint = level.enemySpawnPoints[Random.Range(0, level.enemySpawnPoints.Count)];
                    var spawnedEnemy = Instantiate(chosenEnemy, spawnPoint.position, Quaternion.identity);
                    _enemyCount++;
                    _currentEnemies.Add(spawnedEnemy.gameObject);
                    _combinedDifficulty += spawnedEnemy.difficulty;
                }
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void ResetCombinedDifficulty()
    {
        _combinedDifficulty = 0;
    }

    public void RemoveEnemy(GameObject enemyObject)
    {
        _currentEnemies.Remove(enemyObject);
        _enemyCount--;
    }

    public void ClearEnemies()
    {
        foreach(var enemyObject in _currentEnemies)
        {
            Destroy(enemyObject);
        }
        _enemyCount = 0;
    }
}


   