using Architecture.Controller;
using Architecture.Model;
using Architecture.Model.SelectLevel;
using Architecture.Services.LevelLoad;
using Configs;
using UnityEngine;
using VContainer;

namespace UI
{
    public class LoaderSelectLevel : MonoBehaviour
    {
        private ILevelLoadService _levelLoadService;
        private IModel<SelectLevelData> _selectLevelModel;
        private GameConfig _config;
        private GameStateController _controller;

        [Inject]
        private void Construct(ILevelLoadService levelLoadService, IModel<SelectLevelData> selectLevelModel, GameConfig config,
            GameStateController controller)
        {
            _controller = controller;
            _levelLoadService = levelLoadService;
            _selectLevelModel = selectLevelModel;
            _config = config;
        }

        public void Load()
        {
            _controller.SetPlay();
            var currentLevel = _selectLevelModel.Read().Current;
            var index = _config.LevelConfigs[currentLevel].BuildIndexScene;
            _levelLoadService.LoadLevel(index);
        }
    }
}