using UnityEngine;

namespace Base.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private BoxCollider2D _collider;
        private Collider2D _currentGroundCollider;

        [SerializeField] private float verticalForce = 7f;
        [SerializeField] private float horizontalForce = 5f;

        [SerializeField] LayerMask jumpableGround;
        private float _distToGround;

        private float _horizontalAxisValue;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider = GetComponent<BoxCollider2D>();
            _distToGround = _collider.bounds.extents.y;
        }

        private void Update()
        {
            RaycastHit2D groundRaycast = IsGrounded();

            if (groundRaycast)
            {
                OnGroundCollide(groundRaycast.collider);
                UpdatePlayerVelocity();
            }
        }

        private void OnGroundCollide(Collider2D groundCollider)
        {
            if (_currentGroundCollider == groundCollider) return;

            _currentGroundCollider = groundCollider;
            gameObject.transform.SetParent(_currentGroundCollider.transform);
        }

        private void UpdatePlayerVelocity()
        {
            _horizontalAxisValue = Input.GetAxisRaw("Horizontal");

            _rigidbody2D.velocity = new Vector3(horizontalForce * _horizontalAxisValue, _rigidbody2D.velocity.y);

            if (Input.GetButtonDown("Jump"))
            {
                _rigidbody2D.velocity = new Vector3(_rigidbody2D.velocity.x, verticalForce);
            }
        }

        private RaycastHit2D IsGrounded()
        {
            float maxRayDistance = _distToGround + 0.1f;

            Bounds bounds = _collider.bounds;

            return Physics2D.BoxCast(
                bounds.center,
                bounds.size,
                0f,
                Vector2.down,
                maxRayDistance,
                jumpableGround
            );
        }
    }
}