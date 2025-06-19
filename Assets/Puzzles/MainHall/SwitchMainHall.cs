using Interface;
using Rooms;
using UnityEngine;

namespace Puzzles.MainHall
{
    public class SwitchMainHall : MonoBehaviour, IInteractable
    {
        private bool _switched;
        private RoomDoorUnlocker _whichItem;
        [SerializeField] private GameObject tutorialText;
        [SerializeField] private GameObject arrow;
        public RoomCameraCompletedPuzzle roomCameraCompletedPuzzle;
        
        private void Start()
        {
            _whichItem = GetComponent<RoomDoorUnlocker>();
        }
        
        public void Interact()
        {
            if (!_switched) // Unlock tutorial door
            {
                _whichItem.UnlockDoor();
                roomCameraCompletedPuzzle.MoveCamera();
                transform.localScale = new Vector3((float)-0.3, (float)0.35, 1);
                GetComponent<SpriteRenderer>().color = Color.green;
                _switched = true;
                Destroy(tutorialText);
                Destroy(arrow);
            }
        }
    }
}