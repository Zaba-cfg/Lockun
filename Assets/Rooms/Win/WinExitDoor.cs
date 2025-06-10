using UnityEngine;

namespace Rooms.Win
{
    public class WinExitDoor : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Application.Quit();
            }
        }
    }
}