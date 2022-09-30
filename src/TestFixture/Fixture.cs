using Autofac;
using System;

namespace TestFixture;

public sealed class Fixture
{
    private readonly IContainer container;

    public Fixture()
    {
        var containerBuilder = new ContainerBuilder();
        Register(containerBuilder);
        container = containerBuilder.Build();
    }

    public Fixture(Action<ContainerBuilder> builder)
    {
        var containerBuilder = new ContainerBuilder();
        Register(containerBuilder);
        builder(containerBuilder);
        container = containerBuilder.Build();
    }

    private void Register(ContainerBuilder containerBuilder)
    {
        containerBuilder.RegisterInstance(new Random()).AsSelf().SingleInstance();
        containerBuilder.Register(x => x.Resolve<Random>().Next()).AsSelf().InstancePerDependency();
        containerBuilder.Register(x => Guid.NewGuid()).AsSelf().InstancePerDependency();
    }

    public T Create<T>()
    {
        return container.Resolve<T>();
    }
}
