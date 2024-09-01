using Architecture.Factory;
using Core.Scan.Particle;
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
            builder
                .Register<ParticleFactory>(Lifetime.Transient);
        }

        private static void RegisterScanner(IContainerBuilder builder)
        {
            builder
                .RegisterComponentInHierarchy<ParticleObjectPool>();
        }
    }
}
