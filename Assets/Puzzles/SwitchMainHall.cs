using Interface;
using Rooms;
using UnityEngine;

namespace Puzzles
{
    public class SwitchMainHall : MonoBehaviour, IInteractable
    {
        private bool _switched;
        private RoomDoorUnlocker _whichItem;
        [SerializeField] private GameObject tutorialText;
        [SerializeField] private GameObject arrow;
        
        private void Start()
        {
            _whichItem = GetComponent<RoomDoorUnlocker>();
        }
        
        public void Interact()
        {
            if (!_switched)
            {
                _whichItem.UnlockDoor();
                transform.localScale = new Vector3((float)-0.3, (float)0.35, 1);
                GetComponent<SpriteRenderer>().color = Color.green;
                _switched = true;
                Destroy(tutorialText);
                Destroy(arrow);
            }
        }
    }
}