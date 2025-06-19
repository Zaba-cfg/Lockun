using Character.Scripts;
using Rooms;
using UnityEngine;

namespace Puzzles.Bedroom
{
    public class BedroomMinigameManager : MonoBehaviour
    {
        public BedroomSwitchController[] switches;
        public GameObject player;
        public bool hasWon;
        private RoomDoorUnlocker _roomDoorUnlocker;
        
        public RoomCameraCompletedPuzzle roomCameraCompletedPuzzle; // Camera completed puzzle

        public void CheckWinCondition()
        {
            foreach (var s in switches) // Check if all switches are ON
            {
                if (!s.isOn)
                {
                    player.GetComponent<PlayerMovement>().moveSpeed = 60f;
                    return;
                }
            }
            WinGame();
        }

        private void WinGame()
        {
            roomCameraCompletedPuzzle.MoveCamera();
            Debug.Log("PUZZLE SOLVED!");
            hasWon = true;
            player.GetComponent<PlayerMovement>().moveSpeed = 40f;
            _roomDoorUnlocker = GetComponent<RoomDoorUnlocker>();
            _roomDoorUnlocker.UnlockDoor();
        }
    }
}
