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

    public GameObject player;
    private CharacterController playerCharacterController;


    protected override void Awake()
    {
        base.Awake();
        PopulateLevelData();
    }

    private void Start()
    {
        playerCharacterController = player.GetComponent<CharacterController>();
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
        playerCharacterController.enabled = false;
        player.transform.position = new Vector3(PlayerSpawn.transform.position.x, player.transform.position.y, PlayerSpawn.transform.position.z);
        playerCharacterController.enabled = true;
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
