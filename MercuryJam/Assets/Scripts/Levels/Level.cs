using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
public class Level : MonoBehaviour
{
    public List<Transform> enemySpawnPoints;
    public Transform playerSpawnPoint;
    public Transform cameraLocation;
}
