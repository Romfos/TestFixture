using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using TestFixture.Factories;
using TestFixture.Factories.Collections;
using TestFixture.Factories.Collections.Immutable;
using TestFixture.Factories.Primitives;
using TestFixture.Factories.System;
using TestFixture.Providers;
using TestFixture.Services;

namespace TestFixture;

internal static class SharedFixtureState
{
    internal static readonly Dictionary<Type, object> instances = new()
    {
        [typeof(IRandomService)] = new RandomService()
    };

    internal static readonly ConcurrentDictionary<Type, IFactory> factories = new()
    {
        [typeof(byte)] = new ByteFactory(),
        [typeof(sbyte)] = new SByteFactory(),
        [typeof(short)] = new ShortFactory(),
        [typeof(ushort)] = new UShortFactory(),
        [typeof(int)] = new Int32Factory(),
        [typeof(uint)] = new UInt32Factory(),
        [typeof(long)] = new Int64Factory(),
        [typeof(ulong)] = new UInt64Factory(),
        [typeof(float)] = new FloatFactory(),
        [typeof(double)] = new DoubleFactory(),
        [typeof(decimal)] = new DecimalFactory(),
        [typeof(char)] = new CharFactory(),
        [typeof(string)] = new StringFactory(),
        [typeof(bool)] = new BooleanFactory(),

        [typeof(Guid)] = new GuidFactory(),
        [typeof(Uri)] = new UriFactory(),
        [typeof(TimeSpan)] = new TimeSpanFactory(),
        [typeof(DateTime)] = new DateTimeFactory(),
        [typeof(DateTimeOffset)] = new DateTimeOffsetFactory(),
#if NET6_0_OR_GREATER
        [typeof(TimeOnly)] = new TimeOnlyFactory(),
        [typeof(DateOnly)] = new DateOnlyFactory(),
#endif
    };

    internal static readonly IFactoryProvider[] providers =
    {
        new EnumFactoryProvider(),
        new GenericFactoryProvider(typeof(Nullable<>), typeof(NullableFactory<>)),

        new ArrayFactoryProvider(),
        new GenericFactoryProvider(typeof(List<>), typeof(ListFactory<>)),
        new GenericFactoryProvider(typeof(Dictionary<,>), typeof(DictionaryFactory<,>)),

        new GenericFactoryProvider(typeof(IEnumerable<>), typeof(ListFactory<>)),
        new GenericFactoryProvider(typeof(ICollection<>), typeof(ListFactory<>)),
        new GenericFactoryProvider(typeof(IList<>), typeof(ListFactory<>)),

        new GenericFactoryProvider(typeof(ImmutableArray<>), typeof(ImmutableArrayFactory<>)),
        new GenericFactoryProvider(typeof(ImmutableList<>), typeof(ImmutableListFactory<>)),
        new GenericFactoryProvider(typeof(ImmutableDictionary<,>), typeof(ImmutableDictionaryFactory<,>)),
    };
}
