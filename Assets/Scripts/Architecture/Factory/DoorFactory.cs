using Architecture.Model;
using Architecture.Model.Level;
using Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Architecture.Factory
{
    public class DoorFactory
    {
        private readonly IObjectResolver _container;
        private readonly GameConfig _config;
        private readonly int _currentLevel;

        public DoorFactory(IObjectResolver container, GameConfig config, IModel<LevelData> levelModel)
        {
            _container = container;
            _config = config;
            _currentLevel = levelModel.Read().CurrentLevelData.CurrentLevel;
        }

        public GameObject Create() =>
            _container
                .Instantiate(_config.LevelConfigs[_currentLevel].DoorPrefab);
    }
}