using UnityEngine;

namespace Rooms.Win
{
    public class WinExitDoor : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision) // Triggers when leaving the house from the front door
        {
            if (collision.CompareTag("Player"))
            {
                Application.Quit();
            }
        }
    }
}