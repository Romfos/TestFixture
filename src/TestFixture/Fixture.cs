using System;
using System.Collections.Generic;
using System.Linq;
using TestFixture.Providers;

namespace TestFixture;

public sealed class Fixture
{
    private readonly FactoryContainer? customFactoryContainer;

    public Fixture()
    {
    }

    public Fixture(IFactoryProvider[] customfactoryProviders)
    {
        customFactoryContainer = new FactoryContainer(customfactoryProviders);
    }

    public T Create<T>()
    {
        return (T)Create(typeof(T));
    }

    public IEnumerable<T> Create<T>(int number)
    {
        return Enumerable.Range(0, number).Select(x => Create<T>());
    }

    internal object Create(Type type)
    {
        var factory = customFactoryContainer != null
            ? customFactoryContainer.Resolve(type) ?? SharedFactoryContainer.Resolve(type)
            : SharedFactoryContainer.Resolve(type);

        return factory.Create(this);
    }
}
