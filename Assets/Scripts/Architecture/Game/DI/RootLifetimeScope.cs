using Architecture.Services.Input;
using Architecture.Services.Storage;
using Configs;
using Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Architecture.Game.DI
{
    public class RootLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameConfig _gameConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterConfigs(builder);
            RegisterServices(builder);
            RegisterData(builder);
        }

        private void RegisterConfigs(IContainerBuilder builder)
        {
            builder
                .RegisterInstance(_gameConfig);
        }

        private static void RegisterServices(IContainerBuilder builder)
        {
            builder
                .Register<PCInputReader>(Lifetime.Singleton)
                .AsImplementedInterfaces();
            builder
                .Register<StubStorageService>(Lifetime.Transient)
                .As<IStorageService>();
        }

        private static void RegisterData(IContainerBuilder builder)
        {
            builder
                .Register<GameData>(Lifetime.Singleton);
        }
    }
}
