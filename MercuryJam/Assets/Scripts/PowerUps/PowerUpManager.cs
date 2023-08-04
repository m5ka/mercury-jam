using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : Singleton<PowerUpManager>
{
    public List<GameObject> PowerUps;
    public float _spawnChance = 5.0f;

    public void AttemptSpawnPowerUp(Vector3 position)
    {
        if (Random.Range(0,100) <= _spawnChance)
        {
            Debug.Log(_spawnChance);
            Instantiate(PowerUps[Random.Range(0, PowerUps.Count)], position, Quaternion.identity);
        }
    }
}
