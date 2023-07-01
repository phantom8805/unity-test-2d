using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private float _playerForce = 5f;

    float VerticalForce()
    {
        return _playerForce * 2;
    }
    
    float HorizontalForce()
    {
        return _playerForce;
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalAxisValue = Input.GetAxisRaw("Horizontal");
        
        _rigidbody2D.velocity = new Vector3(HorizontalForce() * horizontalAxisValue, _rigidbody2D.velocity.y);
        
        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody2D.velocity = new Vector3(_rigidbody2D.velocity.x, VerticalForce());
        }
    }
}
