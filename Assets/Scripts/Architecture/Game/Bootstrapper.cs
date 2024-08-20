using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.Game
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
            SceneManager.LoadScene(1);
        }
    }
}