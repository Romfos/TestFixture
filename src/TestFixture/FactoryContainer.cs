using System;
using System.Collections.Concurrent;
using System.Linq;
using TestFixture.Factories;
using TestFixture.Providers;

namespace TestFixture;

internal sealed class FactoryContainer
{
    private readonly IFactoryProvider[] providers;
    private readonly ConcurrentDictionary<Type, IFactory?> factories = new();

    public FactoryContainer(IFactoryProvider[] providers)
    {
        this.providers = providers;
    }

    public IFactory? Resolve(Type type)
    {
        return factories.GetOrAdd(type, type => providers
            .Select(provider => provider.Resolve(type))
            .FirstOrDefault(x => x != null));
    }
}
