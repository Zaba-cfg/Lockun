using System.Collections;
using Interface;
using Rooms;
using UnityEngine;

namespace Character.Scripts
{
    public class PlayerKey : MonoBehaviour, IInteractable
    {
        private RoomDoorUnlocker _whichItem;
        public GameObject player;
        public void Interact()
        {
            _whichItem.UnlockDoor();
            //PlayerText.Instance.ShowMessage("I think the door in the previous room just opened.");

            StartCoroutine(HideAndDestroyAfterDelay(5f));
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
