using Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Architecture.Factory
{
    public class PlayerFactory
    {
        private readonly IObjectResolver _container;
        private readonly GameConfig _config;

        public PlayerFactory(IObjectResolver container, GameConfig config)
        {
            _container = container;
            _config = config;
        }

        public GameObject Create(Vector3 position, Quaternion rotate) =>
            _container
                .Instantiate(Resources.Load<GameObject>(_config.PathConfig.PlayerPrefab), position, rotate);
    }
}