using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Base
{
    public class FinishController : MonoBehaviour
    {
        private AudioSource _audioSource;
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void OnQuitClick()
        {
            Application.Quit();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _audioSource.Play();
                StartCoroutine(LoadNextScene());
            }
        }
        
        IEnumerator LoadNextScene()
        {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(gameObject.scene.buildIndex + 1);
        }
    }
}