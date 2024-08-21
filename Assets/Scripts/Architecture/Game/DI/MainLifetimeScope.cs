using Architecture.Factory;
using VContainer;
using VContainer.Unity;

namespace Architecture.Game.DI
{
    public class MainLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterFactories(builder);
        }

        private static void RegisterFactories(IContainerBuilder builder)
        {
            builder
                .Register<PlayerFactory>(Lifetime.Transient);
        }
    }
}
