using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    [FormerlySerializedAs("_playerForce")] [SerializeField] private float playerForce = 5f;
    private float _horizontalAxisValue;
    private static readonly int Running = Animator.StringToHash("running");

    float VerticalForce()
    {
        return playerForce * 1.5f;
    }
    
    float HorizontalForce()
    {
        return playerForce;
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _horizontalAxisValue = Input.GetAxisRaw("Horizontal");

        if (MathF.Round(_rigidbody2D.velocity.y) == 0)
        {
            _rigidbody2D.velocity = new Vector3(HorizontalForce() * _horizontalAxisValue, _rigidbody2D.velocity.y);

            if (Input.GetButtonDown("Jump"))
            {
                _rigidbody2D.velocity = new Vector3(_rigidbody2D.velocity.x, VerticalForce());
            }
        }
        

        UpdateAnimations();
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
