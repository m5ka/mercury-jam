using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public int currentLevel;

    public List<GameObject> SpawnPoints;
    public List<GameObject> Level1SpawnPoints;
    public List<GameObject> Level2SpawnPoints;
    public List<GameObject> Level3SpawnPoints;

    public GameObject Level1PlayerSpawn;
    public GameObject Level2PlayerSpawn;
    public GameObject Level3PlayerSpawn;


    protected override void Awake()
    {
        base.Awake();
        switch (currentLevel)
        {
            case 1:
                SpawnPoints = Level1SpawnPoints;
                break;
            case 2:
                SpawnPoints = Level2SpawnPoints;
                break;
            case 3:
                SpawnPoints = Level3SpawnPoints;
                break;
            default:
                Debug.Log("Level Spawn fucked");
                break;
        }
    }

    public void NewLevel()
    {
        WaveSystem.Instance.NextWave();
        Debug.Log("Next Level");
    }



}
