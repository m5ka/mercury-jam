using System.Collections;
using System.Collections.Generic;
using System.Text;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
[InfoBox("This game object triggers the next level on collision with the player.")]
public class TriggerNextLevel : MonoBehaviour
{
    private bool _canTrigger = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!_canTrigger)
            return;
        _canTrigger = false;
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.NewLevel();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _canTrigger = true;
    }
}
