using Architecture.Controller;
using Architecture.Factory;
using Architecture.FiniteStateMachine;
using Architecture.Model;
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
            RegisterFsm(builder);
        }

        private static void RegisterFactories(IContainerBuilder builder)
        {
            builder
                .Register<PlayerFactory>(Lifetime.Transient);
        }

        private static void RegisterModels(IContainerBuilder builder)
        {
            builder
                .Register<GameStateModel>(Lifetime.Singleton);
        }

        private static void RegisterControllers(IContainerBuilder builder)
        {
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
