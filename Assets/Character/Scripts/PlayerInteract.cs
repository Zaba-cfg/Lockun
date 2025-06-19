using Interface;
using UnityEngine;

namespace Character.Scripts
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private float interactionRange = 1f;
        [SerializeField] private KeyCode interactionKey = KeyCode.E;
        [SerializeField] private LayerMask interactableLayer;
        [SerializeField] private AudioClip interactionSound;
        [SerializeField] private AudioSource audioSource;
        
        public bool canInteract = true;

        private void Update()
        {
            if (!canInteract) return;

            if (Input.GetKeyDown(interactionKey))
            {
                TryInteract();
            }
        }

        private void TryInteract()
        {
            // Set variables for raycast
            Vector2 origin = transform.position;
            Vector2 direction = Vector2.right * transform.localScale.x;
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, interactionRange, interactableLayer);
            float duration = 2.0f;

            Debug.DrawRay(origin, direction * interactionRange, Color.red, duration); // Debug raycast

            if (hit.collider != null)
            {
                // Play sound
                if (interactionSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(interactionSound);
                }

                IInteractable[] interactables = hit.collider.GetComponents<IInteractable>(); // Get all scripts that are interactable
                foreach (var interactable in interactables)
                {
                    interactable.Interact();
                }

                Debug.Log("HIT: " + hit.collider.name);
            }
            else
            {
                Debug.Log("NO HIT");
            }
        }
    }
}