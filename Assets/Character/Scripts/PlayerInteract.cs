using Interface;
using UnityEngine;

namespace Character.Scripts
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private float interactionRange = 1f;
        [SerializeField] private KeyCode interactionKey = KeyCode.E;
        [SerializeField] private LayerMask interactableLayer;

        private void Update()
        {
            if (Input.GetKeyDown(interactionKey))
            {
                TryInteract();
            }
        }

        private void TryInteract()
        {
            Vector2 origin = transform.position;
            Vector2 direction = Vector2.right * transform.localScale.x;
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, interactionRange, interactableLayer);
            float duration = 2.0f;
            
            Debug.DrawRay(origin, direction * interactionRange, Color.red, duration); // Debug line

            if (hit.collider != null)
            {
                IInteractable[] interactables = hit.collider.GetComponents<IInteractable>(); // Get interactable
                foreach (var interactable in interactables)
                {
                    interactable.Interact();
                }
            }
            
            if (hit.collider != null) //Debug log
            {
                Debug.Log("HIT: " + hit.collider.name);
            }
            else
            {
                Debug.Log("NO HIT");
            }
        }
    }
}