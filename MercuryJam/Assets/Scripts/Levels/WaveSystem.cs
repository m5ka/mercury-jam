using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
public class WaveSystem : Singleton<WaveSystem>
{
    [BoxGroup("Wave"), LabelText("Current")] public int currentWave = 1;
    [BoxGroup("Wave"), LabelText("Score")] public int waveScore = 10;

    [BoxGroup("Next Level"), LabelText("Trigger Object")] public GameObject nextLevelTriggerObject;

    private bool _progessSpawnLevelEnd = true;

    public void NextWave()
    {
        currentWave++;
        waveScore = (int)Math.Ceiling(waveScore * 1.2);
        _progessSpawnLevelEnd = true;
    }

    public void FixedUpdate()
    {
        if (SpawningSystem.Instance.EnemyCount == 0 && SpawningSystem.Instance.enemiesScoreThisWave == waveScore)
        {
            if (_progessSpawnLevelEnd)
            {
                _progessSpawnLevelEnd = false;
                Instantiate(
                    nextLevelTriggerObject,
                    LevelManager.Instance.levels[LevelManager.Instance.currentLevel]
                        .GetComponent<LevelData>().PlayerSpawnPoint.transform.position,
                    Quaternion.identity);
            }
        }
    }
}