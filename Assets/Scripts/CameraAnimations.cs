using UnityEngine;
using Unity.Cinemachine;

public class CameraAnimations : MonoBehaviour
{
    public CinemachineCamera MenuCam;
    public CinemachineCamera PlayCam;

   public void CamSwap()
    {
        MenuCam.Priority = 1;
        PlayCam.Priority = 2;

        
    }


    
}
