using System.Collections;
using Character.Scripts;
using Unity.Cinemachine;
using UnityEngine;

namespace Rooms
{
    public class RoomCameraCompletedPuzzle : MonoBehaviour
    {
        public CinemachineCamera cameraToShowTemporarily; // Camera from the front door
        public GameObject player;

        private CinemachineCamera _previousCamera;
        private float _delay = 2f;
        [SerializeField] private GameObject spriteAsset;
        [SerializeField] private Color color;

        public void MoveCamera()
        {
            // Save all cameras
            CinemachineCamera[] allCams = FindObjectsByType<CinemachineCamera>(FindObjectsSortMode.None);
            _previousCamera = GetActiveCamera(allCams);

            // Temporary active to front door camera
            SetActiveCamera(cameraToShowTemporarily, allCams);

            // Block all movement inputs
            player.GetComponent<PlayerMovement>().canMove = false;

            // Wait and go back to the previous camera
            StartCoroutine(ReturnToPreviousCameraAfterDelay(allCams));
            
            spriteAsset.GetComponent<SpriteRenderer>().color = color;
        }

        private IEnumerator ReturnToPreviousCameraAfterDelay(CinemachineCamera[] allCams)
        {
            yield return new WaitForSeconds(_delay);

            // Go back to previous camera
            SetActiveCamera(_previousCamera, allCams);

            // Unlock player movement inputs
            player.GetComponent<PlayerMovement>().canMove = true;
        }

        private void SetActiveCamera(CinemachineCamera cameraToActivate, CinemachineCamera[] allCams) // Set the camera by priority
        {
            foreach (var cam in allCams)
                cam.Priority = 0;

            if (cameraToActivate != null)
                cameraToActivate.Priority = 10;
        }

        private CinemachineCamera GetActiveCamera(CinemachineCamera[] allCams) // Select the camera by priority
        {
            CinemachineCamera active = null;
            int highest = int.MinValue;

            foreach (var cam in allCams)
            {
                if (cam.Priority > highest)
                {
                    highest = cam.Priority;
                    active = cam;
                }
            }

            return active;
        }
    }
}
