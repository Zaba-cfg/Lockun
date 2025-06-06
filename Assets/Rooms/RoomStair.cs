using Character.Scripts;
using Interface;
using UnityEngine;
using Unity.Cinemachine;

namespace Rooms // FIX THIS SCRIPT, ES UN QUILOMBO
{
    public class RoomStair : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform targetPosition1;
        [SerializeField] private Transform targetPosition2;
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private CinemachineCamera cameraTarget1;
        [SerializeField] private CinemachineCamera cameraTarget2;

        private GameObject _player;
        private bool _movingPlayer;
        private bool _flipflop = true;
        private int _phase;
        private bool _cameraSwitched;

        public void Interact()
        {
            _player = GameObject.FindGameObjectWithTag("Player");

            if (_player != null)
            {
                var movementScript = _player.GetComponent<PlayerMovement>();
                var interactScript = _player.GetComponent<PlayerInteract>();

                if (movementScript != null)
                    movementScript.canMove = false;

                if (interactScript != null)
                    interactScript.canInteract = false;

                _movingPlayer = true;
                _phase = 1;
                _cameraSwitched = false;
            }
        }

        private void Update()
        {
            if (_movingPlayer && _player != null)
            {
                Transform target = null;
                CinemachineCamera targetCam = null;

                if (_flipflop)
                {
                    if (_phase == 1)
                    {
                        target = targetPosition2;
                        targetCam = cameraTarget2;
                    }
                    else if (_phase == 2)
                    {
                        target = targetPosition1;
                        targetCam = cameraTarget1;
                    }
                }
                else
                {
                    if (_phase == 1)
                    {
                        target = targetPosition1;
                        targetCam = cameraTarget1;
                    }
                    else if (_phase == 2)
                    {
                        target = targetPosition2;
                        targetCam = cameraTarget2;
                    }
                }

                if (!_cameraSwitched && targetCam != null)
                {
                    CinemachineCamera[] allCams = FindObjectsByType<CinemachineCamera>(FindObjectsSortMode.None);
                    foreach (var cam in allCams)
                        cam.Priority = 0;
                    
                    targetCam.Priority = 10;
                    _cameraSwitched = true;
                }

                if (target != null)
                {
                    _player.transform.position = Vector3.MoveTowards(
                        _player.transform.position,
                        target.position,
                        moveSpeed * Time.deltaTime
                    );

                    if (Vector3.Distance(_player.transform.position, target.position) < 0.1f)
                    {
                        if (_phase == 1)
                        {
                            _phase = 2;
                            _cameraSwitched = false;
                        }
                        else if (_phase == 2)
                        {
                            _phase = 0;
                            _movingPlayer = false;
                            _flipflop = !_flipflop;

                            var movementScript = _player.GetComponent<PlayerMovement>();
                            var interactScript = _player.GetComponent<PlayerInteract>();

                            if (movementScript != null)
                                movementScript.canMove = true;

                            if (interactScript != null)
                                interactScript.canInteract = true;
                        }
                    }
                }
            }
        }
    }
}
