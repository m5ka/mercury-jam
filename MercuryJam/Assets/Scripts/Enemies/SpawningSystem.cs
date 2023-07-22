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
    private int _enemiesThisWave = 0;
    private int _maxEnemiesThisWave = 10;

    public void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (_enemies.Count < MaxEnemies && _enemiesThisWave < _maxEnemiesThisWave)
            {
                GameObject NewEnemy = Instantiate(Enemy, SpawnPoints[Random.Range(0, SpawnPoints.Count)].transform.position, Quaternion.identity);
                _enemies.Add(NewEnemy);
                _enemiesThisWave++;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}


   