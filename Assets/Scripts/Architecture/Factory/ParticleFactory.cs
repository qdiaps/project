using Configs.Settings;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Architecture.Factory
{
    public class ParticleFactory
    {
        private readonly IObjectResolver _container;
        private readonly GameSettingsConfig _config;

        public ParticleFactory(IObjectResolver container, GameSettingsConfig config)
        {
            _container = container;
            _config = config;
        }

        public GameObject Create(Transform parent) =>
            _container
                .Instantiate(Resources.Load<GameObject>(_config.ParticlePrefab), parent);
    }
}