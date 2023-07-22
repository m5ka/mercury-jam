using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public int currentLevel;

    public List<GameObject> SpawnPoints;
    public List<GameObject> Level1SpawnPoints;
    public List<GameObject> Level2SpawnPoints;
    public List<GameObject> Level3SpawnPoints;

    public GameObject PlayerSpawn;
    public GameObject Level1PlayerSpawn;
    public GameObject Level2PlayerSpawn;
    public GameObject Level3PlayerSpawn;


    protected override void Awake()
    {
        base.Awake();
        PopulateLevelData();
    }

    public void NewLevel()
    {
        WaveSystem.Instance.NextWave();
        currentLevel = Random.Range(1, 4);
        Debug.Log(currentLevel);
        PopulateLevelData();
        UpdatePlayerPosForLevelChange();
    }

    public void UpdatePlayerPosForLevelChange()
    {
        Player.CurrentPlayer.Teleport(new Vector3(PlayerSpawn.transform.position.x, Player.CurrentPlayer.Position.y, PlayerSpawn.transform.position.z));

    }

    public void PopulateLevelData()
    {
        switch (currentLevel)
        {
            case 1:
                SpawnPoints = Level1SpawnPoints;
                PlayerSpawn = Level1PlayerSpawn;
                break;
            case 2:
                SpawnPoints = Level2SpawnPoints;
                PlayerSpawn = Level2PlayerSpawn;
                break;
            case 3:
                SpawnPoints = Level3SpawnPoints;
                PlayerSpawn = Level3PlayerSpawn;
                break;
            default:
                Debug.Log("Level Spawn fucked");
                break;
        }
    }
}
