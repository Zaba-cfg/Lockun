using Interface;
using Unity.Cinemachine;
using UnityEngine;

namespace Managers
{
    public class RoomCameraSwitcher : MonoBehaviour, IInteractable
    {
        public CinemachineCamera cameraToActivate;

        public void Interact()
        {
            CinemachineCamera[] allCams = FindObjectsByType<CinemachineCamera>(FindObjectsSortMode.None);

            foreach (var cam in allCams)
                cam.Priority = 0;

            cameraToActivate.Priority = 10;
        }
    }
}