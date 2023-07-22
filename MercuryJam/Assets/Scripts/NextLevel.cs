using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private bool canTrigger = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("somthing triggering happened");
        if (canTrigger == true)
        {
            canTrigger = false;
            if (other.gameObject.CompareTag("Player"))
            {
                LevelManager.Instance.NewLevel();
                Destroy(gameObject);
                Debug.Log("attempted teleport");
            }
            else
            {
                Debug.Log("that wasnt a player?");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canTrigger = true;
    }
}
