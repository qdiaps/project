using Architecture.Controller;
using UI;
using VContainer;
using VContainer.Unity;

namespace Architecture.Game.DI
{
    public class LearningLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterController(builder);
            RegisterUI(builder);
        }

        private static void RegisterController(IContainerBuilder builder)
        {
            builder
                .RegisterComponentInHierarchy<LearningController>();
        }

        private static void RegisterUI(IContainerBuilder builder)
        {
            builder
                .RegisterComponentInHierarchy<StopLearning>();
            builder
                .RegisterComponentInHierarchy<UpdateLearningImage>();
        }
    }
}
