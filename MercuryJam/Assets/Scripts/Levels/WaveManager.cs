using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
public class WaveManager : Singleton<WaveManager>
{
    [BoxGroup("Wave"), LabelText("WaveDifficulty")] public int waveDifficulty = 3;

    [BoxGroup("Next Level"), LabelText("Trigger Object")] public GameObject nextLevelTriggerObject;

    private bool _ladderShouldSpawn = true;

    public void NextWave()
    {
        waveDifficulty = (int)Math.Ceiling(waveDifficulty * 1.2);
        _ladderShouldSpawn = true;
        SpawnManager.Instance.combinedDifficulty = 0;
        Player.CurrentPlayer.HealPlayer(2);
    }

    public void ResetWave()
    {
        Player.CurrentPlayer.Spawn();
        SpawnManager.Instance.combinedDifficulty = 0;
        HUDManager.Instance.resetPanel.SetActive(false);
    }

    public void FixedUpdate()
    {
        if (SpawnManager.Instance.EnemyCount == 0 && SpawnManager.Instance.combinedDifficulty >= waveDifficulty && !Player.CurrentPlayer.Dead)
        {
            if (_ladderShouldSpawn)
            {
                _ladderShouldSpawn = false;
                Instantiate(
                    nextLevelTriggerObject,
                    LevelManager.Instance.levels[LevelManager.Instance.CurrentLevelIndex]
                        .GetComponent<Level>().playerSpawnPoint.position,
                    Quaternion.identity);
            }
        }
    }
}