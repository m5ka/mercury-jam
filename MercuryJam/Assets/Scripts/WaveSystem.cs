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
        WaveScore = CurrentWave * (10 + CurrentWave);
        progessSpawnLevelEnd = true;
    }

    public void FixedUpdate()
    {
        if (SpawningSystem.Instance.enemyCount == 0 && SpawningSystem.Instance.enemiesScoreThisWave == WaveScore)
        {
            if (progessSpawnLevelEnd==true)
            {
                progessSpawnLevelEnd = false;
                Instantiate(NextLevelObject, LevelManager.Instance.PlayerSpawn.transform.position, Quaternion.identity);
            }
        }
    }
}
