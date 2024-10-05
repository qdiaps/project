using Architecture.Controller;
using Architecture.Services.LevelLoad;
using Configs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.Services.Learning
{
    public class LearningService : ILearningService
    {
        private readonly ILevelLoadService _levelLoadService;
        private readonly GameStateController _controller;
        private readonly GameConfig _config;

        public LearningService(ILevelLoadService levelLoadService, GameStateController controller, GameConfig config)
        {
            _levelLoadService = levelLoadService;
            _controller = controller;
            _config = config;
        }

        public void Setup()
        {
            _controller.SetLearning();
            SceneManager.LoadScene(_config.LearningConfig.BuildIndexScene);
        }

        public void Reset()
        {
            if (PlayerPrefs.HasKey(_config.LearningConfig.PathToSave))
                PlayerPrefs.DeleteKey(_config.LearningConfig.PathToSave);
        }

        public void Stop()
        {
            PlayerPrefs.SetInt(_config.LearningConfig.PathToSave, 0);
            _controller.SetPlay();
            _levelLoadService.LoadLastLevelFromSave();
        }
    }
}