using Architecture.Controller;
using Architecture.FiniteStateMachine;
using Architecture.Model;
using Architecture.Model.Level;
using Architecture.Model.State;
using Architecture.Services.Input;
using Architecture.Services.LevelLoad;
using Architecture.Services.Storage;
using Architecture.Services.Stream;
using Architecture.View;
using Configs;
using Core;
using UI;
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
            RegisterUI(builder);
            RegisterFsm(builder);
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
            builder
                .Register<StateModel>(Lifetime.Singleton)
                .As<IModel<StateData>>();
        }

        private static void RegisterBootstrapper(IContainerBuilder builder)
        {
            builder
                .RegisterComponentInHierarchy<Bootstrapper>();
        }
        
        private static void RegisterUI(IContainerBuilder builder)
        {
            builder
                .RegisterComponentInHierarchy<GameStateView>();
            builder
                .RegisterComponentInHierarchy<PlaySetter>();
            builder
                .Register<GameStateController>(Lifetime.Singleton);
        }
        
        private static void RegisterFsm(IContainerBuilder builder)
        {
            builder
                .Register<Fsm>(Lifetime.Transient);
        }
    }
}
