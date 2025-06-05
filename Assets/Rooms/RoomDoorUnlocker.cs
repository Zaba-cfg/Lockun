using Interface;
using UnityEngine;

namespace Rooms
{
    public class RoomDoorUnlocker : MonoBehaviour, IInteractable
    {
        
        [SerializeField] private GameObject doorToUnlock;
        public void Interact()
        {
            var door2DCollider = doorToUnlock.GetComponent<Collider2D>();
            door2DCollider.enabled = true;
        }
    }
}
