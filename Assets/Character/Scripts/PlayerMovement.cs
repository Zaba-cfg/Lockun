using UnityEngine;

namespace Character.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private KeyCode leftKey = KeyCode.A;
        [SerializeField] private KeyCode rightKey = KeyCode.D;
        [SerializeField] private KeyCode upKey = KeyCode.W;
        [SerializeField] private KeyCode downKey = KeyCode.S;
        [SerializeField] private float moveSpeed = 40f;
        [SerializeField] private float stairSpeed = 20f;

        public bool canMove = true;
        
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
        private void HandleInput() // Input handler
        {
            if (!canMove) return;
            
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
        private void MoveCharacter() // Move with rigidbody
        {
            if (_left)
            {
                _rb.AddForce(Vector2.left * moveSpeed);
                transform.localScale = new Vector3(-1, 2, 1);
                _left = false;
            }

            if (_right)
            {
                _rb.AddForce(Vector2.right * moveSpeed);
                transform.localScale = new Vector3(1, 2, 1);
                _right = false;
            }

            if (_up)
            {
                _rb.AddForce(Vector2.up * stairSpeed);
                _up = false;
            }
        
            if (_down)
            {
                _rb.AddForce(Vector2.down * stairSpeed);
                _down = false;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision) // Detect possible stairs
        {
            if (collision.CompareTag("Stair"))
            {
                _isStairOn = true;
                _rb.gravityScale = 0f;
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
}