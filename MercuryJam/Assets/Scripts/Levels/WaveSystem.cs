using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
public class WaveSystem : Singleton<WaveSystem>
{
    [BoxGroup("Wave"), LabelText("Current")] public int currentWave = 1;
    [BoxGroup("Wave"), LabelText("WaveDifficulty")] public int waveDifficulty = 3;

    [BoxGroup("Next Level"), LabelText("Trigger Object")] public GameObject nextLevelTriggerObject;

    private bool _progessSpawnLevelEnd = true;

    public void NextWave()
    {
        currentWave++;
        waveDifficulty = (int)Math.Ceiling(waveDifficulty * 1.2);
        _progessSpawnLevelEnd = true;
        SpawningSystem.Instance.combinedDifficulty = 0;
        Player.CurrentPlayer.HealPlayer(2);
    }

    public void ResetWave()
    {
        Player.CurrentPlayer.Spawn();
        SpawningSystem.Instance.combinedDifficulty = 0;
        HUDManager.Instance.resetPanel.SetActive(false);
    }

    public void FixedUpdate()
    {
        if (SpawningSystem.Instance.EnemyCount == 0 && SpawningSystem.Instance.combinedDifficulty == waveDifficulty && !Player.CurrentPlayer.Dead)
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