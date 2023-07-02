using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float verticalForce = 7f;
    [SerializeField] private float horizontalForce = 5f;

    private float _horizontalAxisValue;
    private static readonly int Running = Animator.StringToHash("running");

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_rigidbody2D.IsTouchingLayers())
        {
            UpdatePlayerVelocity();
        }

        UpdateAnimations();
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

    private void UpdateAnimations()
    {
        if (_horizontalAxisValue == 0f)
        {
            _animator.SetBool(Running, false);
        }
        else
        {
            _animator.SetBool(Running, true);
            _spriteRenderer.flipX = _horizontalAxisValue < 0f;
        }
    }
}