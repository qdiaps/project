using Architecture.Controller;
using Architecture.Services.Learning;
using Architecture.Services.LevelLoad;
using Configs;
using UnityEngine;
using VContainer;

namespace Architecture.Game
{
    public class Bootstrapper : MonoBehaviour
    {
        private ILevelLoadService _levelLoadService;
        private ILearningService _learningService;
        private GameStateController _controller;
        private GameConfig _config;

        private void Awake() => 
            DontDestroyOnLoad(this);

        [Inject]
        private void Construct(ILevelLoadService levelLoadService, ILearningService learningService, GameStateController controller,
            GameConfig config)
        {
            _levelLoadService = levelLoadService;
            _learningService = learningService;
            _controller = controller;
            _config = config;
            if (CheckLearning())
            {
                _controller.SetPlay();
                LoadLevel();
            }
        }

        private bool CheckLearning()
        {
            if (PlayerPrefs.HasKey(_config.LearningConfig.PathToSave))
                return true;
            _learningService.Setup();
            return false;
        }

        private void LoadLevel() => 
            _levelLoadService.LoadLastLevelFromSave();
    }
}