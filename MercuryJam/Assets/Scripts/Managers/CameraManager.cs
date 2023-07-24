using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
public class CameraManager : Singleton<CameraManager>
{
    public Camera mainCamera;
    public Light mainLight;
    
    public void Teleport(Vector3 position)
    {
        mainCamera.transform.position = position;
        mainLight.transform.position = position;
    }
}
