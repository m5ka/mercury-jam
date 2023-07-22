using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.AI;
public class SpawningSystem : Singleton<SpawningSystem>
{

    public List<GameObject> EnemyTypes;
    public int enemyCount;
    public int MaxEnemies = 5;
    public int enemiesScoreThisWave = 0;

    public void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (enemyCount < MaxEnemies && enemiesScoreThisWave < WaveSystem.Instance.WaveScore)
            {
                int chosenEnemy = Random.Range(0,EnemyTypes.Count);

                if (Instantiate(EnemyTypes[chosenEnemy],
                    LevelManager.Instance.Levels[LevelManager.Instance.currentLevel].GetComponent<LevelData>().SpawnPoints[Random.Range(0, LevelManager.Instance.Levels[LevelManager.Instance.currentLevel].GetComponent<LevelData>().SpawnPoints.Count)].transform.position,
                    Quaternion.identity))
                {
                    enemyCount++;
                }
                enemiesScoreThisWave = enemiesScoreThisWave + EnemyTypes[chosenEnemy].GetComponent<Enemy>().difficulty;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}


   