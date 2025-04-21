using Interface;
using UnityEngine;

namespace Items
{
    public class BookStand : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("Agarraste un libro");
        }
    }
}