using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Puzzles.Library.Scripts
{
    public class LibraryTrap : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
