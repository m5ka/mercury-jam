using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : Singleton<WaveSystem>
{
    public int CurrentWave = 1;
    public int WaveScore = 10;

    public GameObject NextLevelObject;

    bool progessSpawnLevelEnd = true;

    public void NextWave()
    {
        CurrentWave++;
        WaveScore = (int)Math.Ceiling(WaveScore * 1.2);
        progessSpawnLevelEnd = true;
    }

    public void FixedUpdate()
    {
        if (SpawningSystem.Instance.enemyCount == 0 && SpawningSystem.Instance.enemiesScoreThisWave == WaveScore)
        {
            if (progessSpawnLevelEnd==true)
            {
                progessSpawnLevelEnd = false;
                Instantiate(NextLevelObject, LevelManager.Instance.Levels[LevelManager.Instance.currentLevel].GetComponent<LevelData>().PlayerSpawnPoint.transform.position, Quaternion.identity);
            }
        }
    }
}
