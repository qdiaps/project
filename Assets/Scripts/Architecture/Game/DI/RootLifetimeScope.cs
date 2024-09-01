using Architecture.Services.Input;
using Configs.Camera;
using Configs.Player;
using Configs.Scanner;
using Configs.Settings;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Architecture.Game.DI
{
    public class RootLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameSettingsConfig _gameSettingsConfig;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private CameraConfig _cameraConfig;
        [SerializeField] private ParticleConfig _particleConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterInput(builder);
            RegisterConfigs(builder);
        }

        private static void RegisterInput(IContainerBuilder builder)
        {
            builder
                .Register<PCInputReader>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }

        private void RegisterConfigs(IContainerBuilder builder)
        {
            builder
                .RegisterInstance(_gameSettingsConfig);
            builder
                .RegisterInstance(_playerConfig);
            builder
                .RegisterInstance(_cameraConfig);
            builder
                .RegisterInstance(_particleConfig);
        }
    }
}
