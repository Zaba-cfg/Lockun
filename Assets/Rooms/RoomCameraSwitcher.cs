using System;
using Interface;
using Unity.Cinemachine;
using UnityEngine;

namespace Rooms
{
    public class RoomCameraSwitcher : MonoBehaviour, IInteractable
    {
        public CinemachineCamera cameraToActivate;

        public void Interact()
        {
            CinemachineCamera[]
                allCams = FindObjectsByType<CinemachineCamera>(FindObjectsSortMode.None); // Find and set new camera

            foreach (var cam in allCams)
                cam.Priority = 0;

            cameraToActivate.Priority = 10;
        }
    }
}