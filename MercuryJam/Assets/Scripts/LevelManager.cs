using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int currentLevel;

    public List<GameObject> SpawnPoints;
    public List<GameObject> Level1SpawnPoints;
    public List<GameObject> Level2SpawnPoints;
    public List<GameObject> Level3SpawnPoints;

    private void Awake()
    {
        switch (currentLevel)
        {
            case 1:
                SpawnPoints = Level1SpawnPoints;
                Debug.Log("LEVEL1");
                break;
            case 2:
                SpawnPoints = Level2SpawnPoints;
                Debug.Log("LEVEL2");
                break;
            case 3:
                SpawnPoints = Level3SpawnPoints;
                Debug.Log("LEVEL3");
                break;
            default:
                Debug.Log("Level Spawn fucked");
                break;
        }
    }

    public void NewLevel()
    {
        Debug.Log("Next Level");
    }



}
