using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;
    [SerializeField] private KeyCode upKey = KeyCode.W;
    [SerializeField] private KeyCode downKey = KeyCode.S;
    [SerializeField] private float moveSpeed = 40f;
    [SerializeField] private float stairSpeed = 20f;
    
    private Rigidbody2D _rb;
    private Vector2 _movementInput;
    private float _originalGravity;
    private bool _isStairOn;
    private bool _left;
    private bool _right;
    private bool _up;
    private bool _down;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _originalGravity = _rb.gravityScale;
    }
    private void Update()
    {
        HandleInput();
    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }
    
    // Input handler
    private void HandleInput()
    {
        if (Input.GetKey(leftKey))
        {
            _left = true;
        }

        if (Input.GetKey(rightKey))
        {
            _right = true;
        }

        if (Input.GetKey(upKey) && _isStairOn)
        {
            _up = true;
        }
        
        if (Input.GetKey(downKey) && _isStairOn)
        {
            _down = true;
            stairSpeed = 20;
        }
    }
    
    // Move with rigidbody
    private void MoveCharacter()
    {
        if (_left)
        {
            _rb.AddForce(Vector2.left * moveSpeed);
            _left = false;
        }

        if (_right)
        {
            _rb.AddForce(Vector2.right * moveSpeed);
            _right = false;
        }

        if (_up)
        {
            _rb.AddForce(Vector2.up * stairSpeed);
            _up = false;
            _rb.gravityScale = 0f;
        }
        
        if (_down)
        {
            _rb.AddForce(Vector2.down * stairSpeed);
            _down = false;
        }
    }
    
    // Detect possible stairs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stair"))
        {
            _isStairOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stair"))
        {
            _isStairOn = false;
            _rb.gravityScale = _originalGravity;
        }
    }
}