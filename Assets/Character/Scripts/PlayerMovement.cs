using UnityEngine;

namespace Character.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private KeyCode leftKey = KeyCode.A;
        [SerializeField] private KeyCode rightKey = KeyCode.D;
        [SerializeField] private float moveSpeed = 40f;

        public bool canMove = true;
        
        private Rigidbody2D _rb;
        private Vector2 _movementInput;
        private float _originalGravity;
        private float _originalDamping;
        private bool _left;
        private bool _right;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _originalGravity = _rb.gravityScale;
            _originalDamping = _rb.linearDamping;
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
        }
        private void MoveCharacter() // Move with rigidbody
        {
            if (!canMove) return;
            
            if (_left)
            {
                _rb.AddForce(Vector2.left * moveSpeed);
                transform.localScale = new Vector3(-1, 1, 1);
                _left = false;
            }

            if (_right)
            {
                _rb.AddForce(Vector2.right * moveSpeed);
                transform.localScale = new Vector3(1, 1, 1);
                _right = false;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision) // Detect possible stairs
        {
            if (collision.CompareTag("Stair"))
            {
                _rb.AddForce(Vector2.up * moveSpeed);
                _rb.gravityScale = 0f;
                _rb.linearDamping = 10f;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Stair"))
            {
                _rb.gravityScale = _originalGravity;
                _rb.linearDamping = _originalDamping;
            }
        }
    }
}