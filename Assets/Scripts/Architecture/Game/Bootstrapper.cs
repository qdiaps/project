using Architecture.Model;
using Architecture.Model.Level;
using Configs;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace Architecture.Game
{
    public class Bootstrapper : MonoBehaviour
    {
        private IModel<LevelData> _modelLevel;
        private GameConfig _config;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        [Inject]
        private void Construct(IModel<LevelData> modelLevel, GameConfig config)
        {
            _config = config;
            _modelLevel = modelLevel;
            LoadLevel();
        }

        private void LoadLevel()
        {
            var currentLevelIndex = _modelLevel.Read().CurrentLevelData.CurrentLevel;
            SceneManager.LoadScene(_config.LevelConfigs[currentLevelIndex].BuildIndexScene);
        }
    }
}