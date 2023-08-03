using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllPowerUp : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUp();
        }
    }

    public void PickUp()
    {
        SpawnManager.Instance.ClearEnemies();
        Destroy(gameObject);
        SoundManager.Instance.PlayKillAllExplostionSound();
    }
}
