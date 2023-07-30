using UnityEngine;
using UnityEngine.SceneManagement;

namespace Base
{
    public class FinishController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(gameObject.scene.buildIndex + 1);
            }
        }
    }
}