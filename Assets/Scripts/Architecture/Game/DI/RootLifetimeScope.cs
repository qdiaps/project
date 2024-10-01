using Architecture.Controller;
using Architecture.FiniteStateMachine;
using Architecture.Model;
using Architecture.Model.Level;
using Architecture.Model.SelectLevel;
using Architecture.Model.State;
using Architecture.Services.Input;
using Architecture.Services.LevelLoad;
using Architecture.Services.Storage;
using Architecture.Services.Stream;
using Architecture.View;
using Configs;
using Core.Hint;
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
            RegisterModels(builder);
            RegisterBootstrapper(builder);
            RegisterUI(builder);
            RegisterFsm(builder);
            RegisterHintWriter(builder);
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

        private static void RegisterModels(IContainerBuilder builder)
        {
            builder
                .Register<LevelModel>(Lifetime.Singleton)
                .As<IModel<LevelData>>();
            builder
                .Register<StateModel>(Lifetime.Singleton)
                .As<IModel<StateData>>();
            builder
                .Register<SelectLevelModel>(Lifetime.Singleton)
                .As<IModel<SelectLevelData>>();
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
            builder
                .RegisterComponentInHierarchy<Settings>();
            builder
                .RegisterComponentInHierarchy<ChangerSelectLevel>();
            builder
                .RegisterComponentInHierarchy<LoaderSelectLevel>();
        }

        private static void RegisterFsm(IContainerBuilder builder)
        {
            builder
                .Register<Fsm>(Lifetime.Transient);
        }

        private static void RegisterHintWriter(IContainerBuilder builder)
        {
            builder
                .RegisterComponentInHierarchy<HintWriter>();
        }
    }
}
