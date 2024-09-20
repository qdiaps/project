using Architecture.Factory;
using Architecture.FiniteStateMachine;
using Architecture.Model;
using Architecture.Model.Item;
using Architecture.Services.Door;
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
                .Register<ItemModel>(Lifetime.Singleton)
                .As<IModel<ItemData>>();
        }

        private static void RegisterServices(IContainerBuilder builder)
        {
            builder
                .Register<DoorService>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}
