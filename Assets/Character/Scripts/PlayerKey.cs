using System.Collections;
using Interface;
using Rooms;
using Text.Scripts;
using UnityEngine;

namespace Character.Scripts
{
    public class PlayerKey : MonoBehaviour, IInteractable
    {
        [SerializeField] private FloatingText floatingText; //Floating text
        private RoomDoorUnlocker _whichItem;
        public GameObject player;
        public RoomCameraCompletedPuzzle roomCameraCompletedPuzzle; // Camera completed puzzle
        public void Interact()
        {
            roomCameraCompletedPuzzle.MoveCamera();
            _whichItem.UnlockDoor();
            
            floatingText.Show("I think a door just opened."); //Floating text
            
            StartCoroutine(HideAndDestroyAfterDelay(5f)); // Using coroutine to destroy it so the floating text doesn't break
            GetComponent<SpriteRenderer>().enabled = false;
        }

        private IEnumerator HideAndDestroyAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(gameObject);
        }

        
        private void Start()
        {
            _whichItem = GetComponent<RoomDoorUnlocker>();
        }
    }
}
