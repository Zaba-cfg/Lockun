using UnityEngine;

namespace Rooms
{
    public class RoomDoorUnlocker : MonoBehaviour
    {
        
        [SerializeField] private GameObject doorToUnlock;
        [SerializeField] private GameObject spriteToChange;
        
        public Sprite unlockSprite;
        public void UnlockDoor() // Unlock the desire door
        {
            var door2DCollider = doorToUnlock.GetComponent<Collider2D>();
            var doorSpriteRenderer = spriteToChange.GetComponent<SpriteRenderer>();
            doorSpriteRenderer.sprite = unlockSprite;
            door2DCollider.enabled = true;
        }
    }
}
