using UnityEngine;

namespace Puzzles.Library.Scripts
{
    public class LibraryManager : MonoBehaviour
    {
        [SerializeField] private GameObject doorToLock;
        [SerializeField] private GameObject spriteToChange;
        [SerializeField] private Sprite spriteToUse;
        [SerializeField] private GameObject roof;
        [SerializeField] private GameObject floor;
        [SerializeField] private GameObject cameraShake;

        public bool trapActivated;
        public float speed = 2f;
        
        public void CloseRoom()
        {
            var door = doorToLock.GetComponent<Collider2D>();
            var sprite = spriteToChange.GetComponent<SpriteRenderer>();
            var cam = cameraShake.GetComponent<CameraShake>();
            cam.Shake();
            door.enabled = false;
            sprite.sprite = spriteToUse;
            trapActivated = true;
        }
        public void Update()
        {
            if (trapActivated)
            {
                roof.transform.position = Vector3.MoveTowards(roof.transform.position, floor.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
