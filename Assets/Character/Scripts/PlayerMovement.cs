using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] KeyCode leftKey = KeyCode.A;
    [SerializeField] KeyCode rightKey = KeyCode.D;
    [SerializeField] float moveSpeed = 0.01f;

    private void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        if (Input.GetKey(rightKey))
        {
            transform.Translate(Vector2.right * moveSpeed);
            
        }
        else if (Input.GetKey(leftKey))
        {
            transform.Translate(Vector2.left * moveSpeed);
        }
    }
}
