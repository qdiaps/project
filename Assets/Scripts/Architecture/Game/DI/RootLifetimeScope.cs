using Architecture.Model;
using Architecture.Model.Level;
using Architecture.Services.Input;
using Architecture.Services.LevelLoad;
using Architecture.Services.Storage;
using Architecture.Services.Stream;
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
            RegisterModels(builder);
            RegisterBootstrapper(builder);
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
                .Register<JsonStorageService>(Lifetime.Transient)
                .As<IStorageService>();
            builder
                .Register<FileStreamService>(Lifetime.Transient)
                .As<IStreamService>();
            builder
                .Register<LevelLoadService>(Lifetime.Transient)
                .AsImplementedInterfaces();
        }

        private static void RegisterData(IContainerBuilder builder)
        {
            builder
                .Register<GameData>(Lifetime.Singleton);
        }

        private static void RegisterModels(IContainerBuilder builder)
        {
            builder
                .Register<LevelModel>(Lifetime.Singleton)
                .As<IModel<LevelData>>();
        }

        private static void RegisterBootstrapper(IContainerBuilder builder)
        {
            builder
                .RegisterComponentInHierarchy<Bootstrapper>();
        }
    }
}
