using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _collider;

    [SerializeField] private float verticalForce = 7f;
    [SerializeField] private float horizontalForce = 5f;

    [SerializeField] LayerMask jumpableGround;
    private float _distToGround;

    private float _horizontalAxisValue;
    private static readonly int Running = Animator.StringToHash("running");

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
        _distToGround = _collider.bounds.extents.y;
    }

    private void Update()
    {
        if (IsGrounded())
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
        // animations when on air
        if (Math.Abs(_rigidbody2D.velocity.y) > .1f)
        {
        }
        // animations when on ground
        else
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

    private bool IsGrounded()
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