using Interface;
using UnityEngine;

namespace Character.Scripts
{
    public class PlayerInteract : MonoBehaviour
    {
        public float interactionRange = 1f;
        public KeyCode interactionKey = KeyCode.E;
        public LayerMask interactableLayer;

        void Update()
        {
            if (Input.GetKeyDown(interactionKey))
            {
                TryInteract();
            }
        }

        void TryInteract()
        {
            Vector2 origin = transform.position;
            Vector2 direction = Vector2.right * transform.localScale.x;
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, interactionRange, interactableLayer);
            float duration = 2.0f;
        
            // Debug
            Debug.DrawRay(origin, direction * interactionRange, Color.red, duration);

            if (hit.collider != null)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        
            if (hit.collider != null)
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