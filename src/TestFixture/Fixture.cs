using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TestFixture.Factories;
using TestFixture.Providers;

namespace TestFixture;

public sealed class Fixture
{
    private readonly ImmutableArray<IFactoryProvider> providers;
    private readonly ConcurrentDictionary<Type, IFactory> factories = new();

    public Fixture()
    {
        providers = CreateDefaultFactoryProviders().ToImmutableArray();
    }

    public Fixture(IEnumerable<IFactoryProvider> customfactoryProviders)
    {
        providers = CreateDefaultFactoryProviders().Concat(customfactoryProviders).ToImmutableArray();
    }

    private IEnumerable<IFactoryProvider> CreateDefaultFactoryProviders()
    {
        var factoryProviderType = typeof(IFactoryProvider);

        return GetType().Assembly.GetTypes()
            .Where(x => x.IsClass && !x.IsAbstract && !x.IsGenericType)
            .Where(x => factoryProviderType.IsAssignableFrom(x))
            .Select(x => Activator.CreateInstance(x))
            .Cast<IFactoryProvider>();
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
        var factory = factories.GetOrAdd(type, _ => providers
            .Select(provider => provider.Resolve(type))
            .FirstOrDefault(x => x != null) ?? throw new Exception($"Unable to create fixture for {type.FullName}"));

        return factory.Create(this);
    }
}
