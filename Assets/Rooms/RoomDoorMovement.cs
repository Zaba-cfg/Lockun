using Character.Scripts;
using Interface;
using UnityEngine;

namespace Rooms
{
    public class RoomDoorMovement : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform targetPosition;
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private bool teleport;
        [SerializeField] private GameObject whichDoor;

        private GameObject _player;
        private bool _movingPlayer;

        public void Interact()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            if (_player != null)
            {
                // Disable input
                var movementScript = _player.GetComponent<PlayerMovement>();
                if (movementScript != null)
                {
                    movementScript.canMove = false;
                }

                _movingPlayer = true;

                if (teleport && whichDoor != null)
                {
                    _player.transform.position = whichDoor.transform.position;
                }
            }
        }

        private void Update()
        {
            if (_movingPlayer && _player != null)
            {
                // Move
                _player.transform.position = Vector3.MoveTowards(
                    _player.transform.position,
                    targetPosition.position,
                    moveSpeed * Time.deltaTime
                );

                // Stop
                if (Vector3.Distance(_player.transform.position, targetPosition.position) < 0.1f)
                {
                    _movingPlayer = false;
                    var movementScript = _player.GetComponent<PlayerMovement>();
                    if (movementScript != null)
                    {
                        movementScript.canMove = true; // Enable input
                    }
                }
            }
        }
    }
}

