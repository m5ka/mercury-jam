using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.AI;

public class SpawningSystem : MonoBehaviour
{
    public List<GameObject> SpawnPoints;

    public GameObject Enemy;
    private List<GameObject> _enemies = new List<GameObject>();
    public int MaxEnemies = 5;
    private int _enemiesScoreThisWave = 0;
    private int _maxEnemiesThisWave = 10;

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
                GameObject NewEnemy = Instantiate(Enemy, SpawnPoints[Random.Range(0, SpawnPoints.Count)].transform.position, Quaternion.identity);
                _enemies.Add(NewEnemy);
                _enemiesScoreThisWave++;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}


   