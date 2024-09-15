using Architecture.Controller;
using Architecture.Factory;
using Architecture.FiniteStateMachine;
using Architecture.Model;
using Architecture.Model.Item;
using Architecture.Model.State;
using Architecture.Services.Door;
using Architecture.View;
using VContainer;
using VContainer.Unity;

namespace Architecture.Game.DI
{
    public class MainLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterFactories(builder);
            RegisterModels(builder);
            RegisterControllers(builder);
            RegisterViews(builder);
            RegisterFsm(builder);
            RegisterServices(builder);
        }

        private static void RegisterFactories(IContainerBuilder builder)
        {
            builder
                .Register<PlayerFactory>(Lifetime.Transient);
            builder
                .Register<KeyFactory>(Lifetime.Transient);
            builder
                .Register<DoorFactory>(Lifetime.Transient);
        }

        private static void RegisterModels(IContainerBuilder builder)
        {
            builder
                .Register<StateModel>(Lifetime.Singleton)
                .As<IModel<StateData>>();
            builder
                .Register<ItemModel>(Lifetime.Singleton)
                .As<IModel<ItemData>>();
        }

        private static void RegisterControllers(IContainerBuilder builder)
        {
            builder
                .Register<GameStateController>(Lifetime.Singleton);
        }

        private static void RegisterViews(IContainerBuilder builder)
        {
            builder
                .RegisterComponentInHierarchy<GameStateView>();
        }

        private static void RegisterFsm(IContainerBuilder builder)
        {
            builder
                .Register<Fsm>(Lifetime.Transient);
        }

        private static void RegisterServices(IContainerBuilder builder)
        {
            builder
                .Register<DoorService>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}
