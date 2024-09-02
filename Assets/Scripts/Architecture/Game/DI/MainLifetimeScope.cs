using Architecture.Factory;
using Core.Scan;
using VContainer;
using VContainer.Unity;

namespace Architecture.Game.DI
{
    public class MainLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterFactories(builder);
            RegisterScanner(builder);
        }

        private static void RegisterFactories(IContainerBuilder builder)
        {
            builder
                .Register<PlayerFactory>(Lifetime.Transient);
        }

        private static void RegisterScanner(IContainerBuilder builder)
        {
            builder
                .Register<ScannerModel>(Lifetime.Singleton);
        }
    }
}
