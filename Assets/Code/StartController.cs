using UnityEngine;
using UnityEngine.SceneManagement;

namespace Base
{
    public class StartController : MonoBehaviour
    {
        public void onStartButtonClick()
        {
            SceneManager.LoadScene(gameObject.scene.buildIndex + 1);
        }
    }
}