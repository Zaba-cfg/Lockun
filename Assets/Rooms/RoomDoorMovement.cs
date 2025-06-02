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
        [SerializeField] private bool flipSpriteRight;

        private GameObject _player;
        private bool _movingPlayer;

        public void Interact()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            
            if (_player != null)
            {
                var movementScript = _player.GetComponent<PlayerMovement>();
                var interactScript = _player.GetComponent<PlayerInteract>();
                
                if (movementScript != null) // Disable input
                {
                    movementScript.canMove = false;
                    interactScript.canInteract = false;
                }

                _movingPlayer = true;

                if (teleport && whichDoor != null) // TP to selected door
                {
                    _player.transform.position = whichDoor.transform.position;
                }

                if (flipSpriteRight) // flip sprite to the right
                {
                    _player.transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }

        private void Update()
        {
            if (_movingPlayer && _player != null) // Move player
            {
                _player.transform.position = Vector3.MoveTowards(_player.transform.position,
                    targetPosition.position,
                    moveSpeed * Time.deltaTime
                    );
                
                if (Vector3.Distance(_player.transform.position, targetPosition.position) < 0.1f) // Stop player
                {
                    _movingPlayer = false;
                    var movementScript = _player.GetComponent<PlayerMovement>();
                    var interactScript = _player.GetComponent<PlayerInteract>();
                    if (movementScript != null)
                    {
                        movementScript.canMove = true; // Enable input
                        interactScript.canInteract = true;
                    }
                }
            }
        }
    }
}

