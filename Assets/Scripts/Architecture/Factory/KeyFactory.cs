using Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Architecture.Factory
{
    public class KeyFactory
    {
        private readonly IObjectResolver _container;
        private readonly GameConfig _config;

        public KeyFactory(IObjectResolver container, GameConfig config)
        {
            _container = container;
            _config = config;
        }

        public void Create(Vector3 position) =>
            _container
                .Instantiate(Resources.Load<GameObject>(_config.PathConfig.KeyPrefab), position, Quaternion.identity);
    }
}