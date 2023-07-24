using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
public class WaveManager : Singleton<WaveManager>
{
    public int WaveDifficulty => _waveDifficulty;
    
    public GameObject nextLevelTriggerObject;
    public int initialWaveDifficulty = 3;

    private int _waveDifficulty;
    private bool _ladderShouldSpawn = true;

    public void NextWave()
    {
        _waveDifficulty = (int)Math.Ceiling(_waveDifficulty * 1.2);
        _ladderShouldSpawn = true;
        SpawnManager.Instance.ResetCombinedDifficulty();
        Player.CurrentPlayer.HealPlayer(2);
    }

    public void ResetWave()
    {
        _waveDifficulty = initialWaveDifficulty;
        Player.CurrentPlayer.Spawn();
        SpawnManager.Instance.ResetCombinedDifficulty();
        HUDManager.Instance.resetPanel.SetActive(false);
    }

    private void Start()
    {
        _waveDifficulty = initialWaveDifficulty;
    }
    
    private void FixedUpdate()
    {
        if (SpawnManager.Instance.EnemyCount == 0 && SpawnManager.Instance.CombinedDifficulty >= _waveDifficulty && !Player.CurrentPlayer.Dead)
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