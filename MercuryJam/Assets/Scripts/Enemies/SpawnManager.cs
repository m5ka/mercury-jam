using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
public class SpawnManager : Singleton<SpawnManager>
{
    public int EnemyCount => _enemyCount;

    [BoxGroup("Enemies"), LabelText("Types")] public List<GameObject> enemyTypes;
    [BoxGroup("Enemies"), LabelText("Maximum number")] public int maxEnemies = 5;
    [BoxGroup("Enemies"), LabelText("CombinedDifficulty")] public int combinedDifficulty = 0;

    private List<GameObject> _currentEnemies;
    private int _enemyCount = 0;
    
    public void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (_enemyCount < maxEnemies && combinedDifficulty < WaveManager.Instance.waveDifficulty)
            {
                int chosenEnemy = Random.Range(0,enemyTypes.Count);
                if (Player.CurrentPlayer.CurrentHealth >0)
                {
                    GameObject go = Instantiate(enemyTypes[chosenEnemy],
                    LevelManager.Instance.levels[LevelManager.Instance.CurrentLevelIndex]
                        .GetComponent<Level>().enemySpawnPoints[
                            Random.Range(0, LevelManager.Instance.levels[LevelManager.Instance.CurrentLevelIndex]
                                .GetComponent<Level>().enemySpawnPoints.Count)
                        ].position,
                    Quaternion.identity);
                    
                    _enemyCount++;
                    _currentEnemies.Add(go);                    
                    combinedDifficulty = combinedDifficulty + enemyTypes[chosenEnemy].GetComponent<Enemy>().difficulty;
                }
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void DecreaseCount()
    {
        _enemyCount--;
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


   