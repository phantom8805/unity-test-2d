using UnityEngine;
using UnityEngine.SceneManagement;

namespace Base.Player
{
    public class PlayerLife : MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody2D _rigidbody2D;
        private static readonly int Dead = Animator.StringToHash("dead");

        [SerializeField] private float fatalFallDistance = 6f;
        private float _fallStartedAtPosition;
        private bool _isFalling;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            PlayerFalling();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Trap"))
            {
                DieAnimationAndDisable();
            }
        }

        private void PlayerFalling()
        {
            if (_rigidbody2D.velocity.y < 0.1f)
            {
                if (!_isFalling) _fallStartedAtPosition = _rigidbody2D.position.y;
                _isFalling = true;
            }
            else
            {
                _isFalling = false;
                _fallStartedAtPosition = 0;
            }

            if (_fallStartedAtPosition - _rigidbody2D.position.y > fatalFallDistance)
            {
                _isFalling = false;
                _fallStartedAtPosition = 0;

                DieAnimationAndDisable();
            }
        }

        private void DieAnimationAndDisable()
        {
            _animator.SetTrigger(Dead);
            _rigidbody2D.isKinematic = true;
            _rigidbody2D.simulated = false;
        }

        private void OnDieAnimationEnd()
        {
            SceneManager.LoadScene(gameObject.scene.name);
        }
    }
}