using Interface;
using Rooms;
using UnityEngine;

namespace Puzzles
{
    public class SwitchMainHall : MonoBehaviour, IInteractable
    {
        private bool _switched;
        private RoomDoorUnlocker _whichDoor;
        [SerializeField] private GameObject tutorialText;
        [SerializeField] private GameObject arrow;
        
        private void Start()
        {
            _whichDoor = GetComponent<RoomDoorUnlocker>();
        }
        
        public void Interact()
        {
            if (!_switched)
            {
                _whichDoor.UnlockDoor();
                transform.localScale = new Vector3((float)-0.3, (float)0.35, 1);
                GetComponent<SpriteRenderer>().color = Color.green;
                _switched = true;
                Destroy(tutorialText);
                Destroy(arrow);
            }
        }
    }
}