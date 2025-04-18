using UnityEngine;

public class CharacterInteract : MonoBehaviour
{
    [SerializeField] KeyCode interactKey = KeyCode.E;
    private GameObject currentInteractable;

    private void Update()
    {
        CheckInteract();
    }

    private void CheckInteract()
    {
        if (Input.GetKeyDown(interactKey) && currentInteractable != null)
        {
            print("Interacted with " + currentInteractable.name);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            currentInteractable = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable") && collision.gameObject == currentInteractable)
        {
            currentInteractable = null;
        }
    }
}
