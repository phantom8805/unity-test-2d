using System;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private static readonly int AnimatorStateField = Animator.StringToHash("state");

    private enum MovementState
    {
        Idle,
        Running,
        Jumping,
        Falling
    }

    MovementState _previousMovementState = MovementState.Idle;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateAnimations(_rigidbody2D.velocity);
    }

    private void UpdateAnimations(Vector2 velocity)
    {
        MovementState state;

        // animations when on air
        if (Math.Abs(velocity.y) > .1f)
        {
            state = velocity.y > 0 ? MovementState.Jumping : MovementState.Falling;
        }
        // animations when on ground
        else
        {
            if (Math.Abs(velocity.x) < .1f)
            {
                state = MovementState.Idle;
            }
            else
            {
                state = MovementState.Running;
                _spriteRenderer.flipX = velocity.x < 0f;
            }
        }

        if (_previousMovementState != state)
        {
            _previousMovementState = state;
            _animator.SetInteger(AnimatorStateField, (int)state);
        }
    }
}