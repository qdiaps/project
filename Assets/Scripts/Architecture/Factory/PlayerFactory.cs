using Configs.Settings;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Architecture.Factory
{
    public class PlayerFactory
    {
        private readonly IObjectResolver _container;
        private readonly GameSettingsConfig _gameSettingsConfig;

        public PlayerFactory(IObjectResolver container, GameSettingsConfig gameSettingsConfig)
        {
            _container = container;
            _gameSettingsConfig = gameSettingsConfig;
        }

        public GameObject Create(Vector3 position, Quaternion rotate) =>
            _container
                .Instantiate(Resources.Load<GameObject>(_gameSettingsConfig.PlayerPrefab), position, rotate);
    }
}