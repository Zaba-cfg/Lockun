using Character.Scripts;
using Interface;
using Rooms;
using Text.Scripts;
using UnityEngine;

namespace Puzzles.Library.Scripts
{
    public class LibrarySwitch : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool correctAnswer;
        [SerializeField] private GameObject switchManager;
        public RoomCameraCompletedPuzzle roomCameraCompletedPuzzle;
        public FloatingText floatingText;
        public GameObject unlockFrontDoor;
        public GameObject player;
        private bool _correctAnswer;
        public void Interact()
        {
            if (correctAnswer)
            {
                player.GetComponent<PlayerMovement>().moveSpeed = 60f;
                roomCameraCompletedPuzzle.MoveCamera();
                floatingText.Show("I Have to get out RIGHT NOW!");
                Debug.Log("PUZZLE SOLVED");
                correctAnswer = true;
                unlockFrontDoor.GetComponent<Collider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                if (!_correctAnswer)
                {
                    var manager = switchManager.GetComponent<LibraryManager>();
                    manager.CloseRoom();
                }
            }
        }
    }
}
