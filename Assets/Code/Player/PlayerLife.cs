using UnityEngine;
using UnityEngine.SceneManagement;

namespace Base.Player
{
    public class PlayerLife : MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody2D _rigidbody2D;
        private static readonly int Dead = Animator.StringToHash("dead");

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Trap"))
            {
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