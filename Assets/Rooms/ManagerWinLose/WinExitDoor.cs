using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rooms.ManagerWinLose
{
    public class WinExitDoor : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision) // Triggers when leaving the house from the front door
        {
            if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene("VictoryScreen");
            }
        }
    }
}