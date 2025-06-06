using UnityEngine;

namespace Rooms
{
    public class RoomLightController : MonoBehaviour
    {
        public GameObject darkOverlay;

        private void OnTriggerEnter2D(Collider2D other) // Turn lights ON
        {
            if (other.CompareTag("Player"))
            {
                darkOverlay.SetActive(false);
            }
        }
        private void OnTriggerExit2D(Collider2D other) // Turn lights OFF
        {
            if (other.CompareTag("Player"))
            {
                darkOverlay.SetActive(true);
            }
        }
    }
}
