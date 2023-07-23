using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
public class CameraManager : Singleton<CameraManager>
{
    public Camera mainCamera;
    
    public void TeleportCamera(Camera camera, Vector3 desiredPosition)
    {
        camera.transform.position = desiredPosition;
    }
}
