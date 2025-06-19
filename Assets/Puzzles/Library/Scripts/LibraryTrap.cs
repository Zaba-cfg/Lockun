using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Puzzles.Library.Scripts
{
    public class LibraryTrap : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision) // Kill the player upon touching the roof
        {
            if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
