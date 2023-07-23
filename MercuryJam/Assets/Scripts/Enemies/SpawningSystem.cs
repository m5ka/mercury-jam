using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
public class SpawningSystem : Singleton<SpawningSystem>
{
    public int EnemyCount => _enemyCount;
    public List<GameObject> currentEnemies = new List<GameObject>();

    [BoxGroup("Enemies"), LabelText("Types")] public List<GameObject> enemyTypes;
    [BoxGroup("Enemies"), LabelText("Maximum number")] public int maxEnemies = 5;
    [BoxGroup("Enemies"), LabelText("CombinedDifficulty")] public int combinedDifficulty = 0;

    private int _enemyCount = 0;
    
    public void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (_enemyCount < maxEnemies && combinedDifficulty < WaveSystem.Instance.waveDifficulty)
            {
                int chosenEnemy = Random.Range(0,enemyTypes.Count);
                if (Player.CurrentPlayer.CurrentHealth >0)
                {
                    GameObject go = Instantiate(enemyTypes[chosenEnemy],
                    LevelManager.Instance.levels[LevelManager.Instance.currentLevel]
                        .GetComponent<LevelData>().SpawnPoints[
                            Random.Range(0, LevelManager.Instance.levels[LevelManager.Instance.currentLevel]
                                .GetComponent<LevelData>().SpawnPoints.Count)
                        ].transform.position,
                    Quaternion.identity);
                    
                    _enemyCount++;
                    currentEnemies.Add(go);                    
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

    public void ClearEnemies()
    {
        foreach(GameObject go in currentEnemies)
        {
            Destroy(go);
        }
        _enemyCount = 0;
    }
}


   