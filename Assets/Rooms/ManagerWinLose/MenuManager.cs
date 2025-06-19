using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rooms.ManagerWinLose
{
    public class MenuManager : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("LockunHouse");
        }

        public void ExitGame()
        {
            Application.Quit();
            Debug.Log("Game Closed");
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}