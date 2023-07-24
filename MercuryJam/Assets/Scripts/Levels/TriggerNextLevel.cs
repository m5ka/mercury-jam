using System.Collections;
using System.Collections.Generic;
using System.Text;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
[InfoBox("This game object triggers the next level on collision with the player.")]
public class TriggerNextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.NewLevel();
            WaveManager.Instance.NextWave();
            Destroy(gameObject);
        }
    }
}
