using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TestFixture.Factories;
using TestFixture.Factories.Collections;
using TestFixture.Factories.Collections.Immutable;
using TestFixture.Factories.Primitives;
using TestFixture.Providers;
using TestFixture.Services;

namespace TestFixture;

public sealed class Fixture
{
    private static readonly IFactoryProvider[] defaultFactoryProviders =
    {
        new TypeFactoryProvider(typeof(IRandomService), typeof(RandomServiceFactory)),

        new TypeFactoryProvider(typeof(bool), typeof(BooleanFactory)),
        new TypeFactoryProvider(typeof(int), typeof(Int32Factory)),
        new TypeFactoryProvider(typeof(long), typeof(Int64Factory)),
        new TypeFactoryProvider(typeof(Guid), typeof(GuidFactory)),
        new TypeFactoryProvider(typeof(string), typeof(StringFactory)),
        new TypeFactoryProvider(typeof(DateTime), typeof(DateTimeFactory)),
        new TypeFactoryProvider(typeof(TimeSpan), typeof(TimeSpanFactory)),
        new TypeFactoryProvider(typeof(Uri), typeof(UriFactory)),
        new TypeFactoryProvider(typeof(double), typeof(DoubleFactory)),
        new TypeFactoryProvider(typeof(decimal), typeof(DecimalFactory)),
        new TypeFactoryProvider(typeof(byte), typeof(ByteFactory)),
        new TypeFactoryProvider(typeof(char), typeof(CharFactory)),

        new EnumFactoryProvider(),
        new GenericFactoryProvider(typeof(Nullable<>), typeof(NullableFactory<>)),

        new ArrayFactoryProvider(),
        new GenericFactoryProvider(typeof(List<>), typeof(ListFactory<>)),
        new GenericFactoryProvider(typeof(Dictionary<,>), typeof(DictionaryFactory<,>)),

        new GenericFactoryProvider(typeof(ImmutableArray<>), typeof(ImmutableArrayFactory<>)),
        new GenericFactoryProvider(typeof(ImmutableList<>), typeof(ImmutableListFactory<>)),
        new GenericFactoryProvider(typeof(ImmutableDictionary<,>), typeof(ImmutableDictionaryFactory<,>)),
    };

    private readonly IFactoryProvider[] providers;
    private readonly ConcurrentDictionary<Type, IFactory> factories = new();

    public Fixture()
    {
        providers = defaultFactoryProviders;
    }

    public Fixture(IEnumerable<IFactoryProvider> customfactoryProviders)
    {
        providers = customfactoryProviders.Concat(defaultFactoryProviders).ToArray();
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
