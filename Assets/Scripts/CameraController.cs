using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera playerCamera;
    public CinemachineVirtualCamera regionCamera;



    private bool isPlayerCamera = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchPriority()
    {
        if (isPlayerCamera)
        {
            playerCamera.Priority = 0;
            regionCamera.Priority = 1;
        }
        else
        {
            playerCamera.Priority = 1;
            regionCamera.Priority = 0;
        }
        isPlayerCamera = !isPlayerCamera;
    }
}
