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
    private List<List<GameObject>> CompiledSpawnPoints = new List<List<GameObject>>();

    private void Start()
    {
        CompiledSpawnPoints.Add(Level1SpawnPoints);
        CompiledSpawnPoints.Add(Level2SpawnPoints);
        CompiledSpawnPoints.Add(Level3SpawnPoints);

        switch (currentLevel)
        {
            case 1:
                SpawnPoints = CompiledSpawnPoints[0];
                break;
            case 2:
                SpawnPoints = CompiledSpawnPoints[1];
                break;
            case 3:
                SpawnPoints = CompiledSpawnPoints[2];
                break;


        }
    }



}
