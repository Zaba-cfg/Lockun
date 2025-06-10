using System.Collections;
using Character.Scripts;
using Unity.Cinemachine;
using UnityEngine;

namespace Rooms
{
    public class RoomCameraCompletedPuzzle : MonoBehaviour
    {
        public CinemachineCamera cameraToShowTemporarily; // Cámara a mostrar (por ejemplo, del inicio)
        public GameObject player;

        private CinemachineCamera _previousCamera;
        private float _delay = 2f;
        [SerializeField] private GameObject spriteAsset;
        [SerializeField] private Color color;

        public void MoveCamera()
        {
            // Guardar todas las cámaras
            CinemachineCamera[] allCams = FindObjectsByType<CinemachineCamera>(FindObjectsSortMode.None);
            _previousCamera = GetActiveCamera(allCams);

            // Activar la cámara temporal
            SetActiveCamera(cameraToShowTemporarily, allCams);

            // Bloquear movimiento del jugador
            player.GetComponent<PlayerMovement>().canMove = false;

            // Esperar y volver a la cámara anterior
            StartCoroutine(ReturnToPreviousCameraAfterDelay(allCams));
            
            spriteAsset.GetComponent<SpriteRenderer>().color = color;
        }

        private IEnumerator ReturnToPreviousCameraAfterDelay(CinemachineCamera[] allCams)
        {
            yield return new WaitForSeconds(_delay);

            // Volver a la cámara anterior
            SetActiveCamera(_previousCamera, allCams);

            // Desbloquear movimiento del jugador
            player.GetComponent<PlayerMovement>().canMove = true;
        }

        private void SetActiveCamera(CinemachineCamera cameraToActivate, CinemachineCamera[] allCams)
        {
            foreach (var cam in allCams)
                cam.Priority = 0;

            if (cameraToActivate != null)
                cameraToActivate.Priority = 10;
        }

        private CinemachineCamera GetActiveCamera(CinemachineCamera[] allCams)
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
