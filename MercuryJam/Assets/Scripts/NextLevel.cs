using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private bool canTrigger = true;

    private void OnTriggerEnter(Collider other)
    {
        if (canTrigger == true)
        {
            canTrigger = false;
            if (other.gameObject == Player.CurrentPlayer)
            {
                LevelManager.Instance.NewLevel();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canTrigger = true;
    }
}
