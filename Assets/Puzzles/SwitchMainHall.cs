using Interface;
using UnityEngine;

namespace Puzzles
{
    public class SwitchMainHall : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("Agarraste un libro");
            DestroyGameObject();
        }

        private void DestroyGameObject ()
        {
            Destroy(gameObject);
        }
    }
}