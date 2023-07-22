using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.AI;
public class SpawningSystem : MonoBehaviour
{
    public List<GameObject> SpawnPoints;

    public List<GameObject> EnemyTypes;
    private List<GameObject> _enemies = new List<GameObject>();
    public int MaxEnemies = 5;
    private int _enemiesScoreThisWave = 0;

    public WaveSystem WaveSystem;

    public void Awake()
    {
        WaveSystem = GetComponent<WaveSystem>();
    }

    public void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (_enemies.Count < MaxEnemies && _enemiesScoreThisWave < WaveSystem.WaveScore)
            {
                int chosenEnemy = Random.Range(0,EnemyTypes.Count);
                
                GameObject NewEnemy = Instantiate(EnemyTypes[chosenEnemy], SpawnPoints[Random.Range(0, SpawnPoints.Count)].transform.position, Quaternion.identity);
                _enemies.Add(NewEnemy);
                _enemiesScoreThisWave = _enemiesScoreThisWave + EnemyTypes[chosenEnemy].GetComponent<EnemyStats>().difficulty;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}


   