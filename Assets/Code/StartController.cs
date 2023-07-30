using UnityEngine;
using UnityEngine.SceneManagement;

namespace Base
{
    public class StartController : MonoBehaviour
    {
        public void OnStartButtonClick()
        {
            SceneManager.LoadScene(gameObject.scene.buildIndex + 1);
        }
    }
}