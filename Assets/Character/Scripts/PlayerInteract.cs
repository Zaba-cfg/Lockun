using UnityEngine;

public class CharacterInteract : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    private GameObject _currentInteractable;

    private void Update()
    {
        CheckInteract();
    }
    private void CheckInteract()
    {
        if (Input.GetKeyDown(interactKey) && _currentInteractable != null)
        {
            print("Interacted with " + _currentInteractable.name);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            _currentInteractable = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable") && collision.gameObject == _currentInteractable)
        {
            _currentInteractable = null;
        }
    }
}
