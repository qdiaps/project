using Configs.Level;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.Game
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private LevelConfig[] _levelConfigs;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
            SceneManager.LoadScene(_levelConfigs[0].BuildIndexScene);
        }
    }
}