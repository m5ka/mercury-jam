using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{
    public List<GameObject> SpawnPoints;

    public GameObject Enemy;

    private void Start()
    {
        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            Instantiate(Enemy, SpawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}

   