using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using TestFixture.Factories;
using TestFixture.Factories.Collections;
using TestFixture.Factories.Primitives;
using TestFixture.Providers;

namespace TestFixture;

public sealed class Fixture
{
    private static readonly IFactoryProvider[] defaultFactoryProviders =
    {
        new TypeFactoryProvider(typeof(int), typeof(Int32Factory)),
        new TypeFactoryProvider(typeof(Guid), typeof(GuidFactory)),
        new TypeFactoryProvider(typeof(string), typeof(StringFactory)),
        new ArrayFactoryProvider(),
        new GenericTypeFactory(typeof(List<>), typeof(ListFactory<>))
    };

    private readonly IFactoryProvider[] providers;
    private readonly ConcurrentDictionary<Type, IFactory> factories = new();

    public Fixture()
    {
        providers = defaultFactoryProviders;
    }

    public Fixture(IEnumerable<IFactoryProvider> customfactoryProviders)
    {
        providers = defaultFactoryProviders.Concat(customfactoryProviders).ToArray();
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
            .FirstOrDefault(x => x != null) ?? new DefaultClassFactory(type));

        return factory.Create(this);
    }
}
