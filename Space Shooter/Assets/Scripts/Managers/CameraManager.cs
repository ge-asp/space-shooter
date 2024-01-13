using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    enum VirtualCameras
    {
        FollowCamera,
    }

    [SerializeField]
    List<GameObject> _virtualCameras;

    void Start()
    {
        SetActiveCamera(VirtualCameras.FollowCamera);
        
    }

    void SetActiveCamera(VirtualCameras camera)
    {
        foreach (GameObject virtualCamera in _virtualCameras)
        {
            virtualCamera.SetActive(virtualCamera.tag.Equals(camera.ToString()));
        }
    }
}
