using Architecture.Services.Input;
using Configs.Settings;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Architecture.Game.DI
{
    public class RootLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameSettingsConfig _gameSettingsConfig;
        
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
        }
    }
}
