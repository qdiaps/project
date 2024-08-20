using Architecture.Services.Input;
using VContainer;
using VContainer.Unity;

public class RootLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        RegisterInput(builder);
    }

    private static void RegisterInput(IContainerBuilder builder)
    {
        builder
            .Register<PCInputReader>(Lifetime.Singleton)
            .AsImplementedInterfaces();
    }
}
