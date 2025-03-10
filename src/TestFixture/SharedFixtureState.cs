using System.Collections.Concurrent;
using System.Collections.Immutable;
using TestFixture.Factories;
using TestFixture.Factories.Collections;
using TestFixture.Factories.Collections.Concurrent;
using TestFixture.Factories.Collections.Immutable;
using TestFixture.Services;
using TestFixture.Factories.Primitives;
using TestFixture.Factories.System;
using TestFixture.GenericFactories;

#if NET
using System.Collections.Frozen;
using TestFixture.Factories.Collections.Frozen;
#endif

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
#if NET
        [typeof(TimeOnly)] = new TimeOnlyFactory(),
        [typeof(DateOnly)] = new DateOnlyFactory(),
#endif
    };

    internal static readonly IGenericFactory[] genericFactories =
    {
        new EnumGenericFactory(),
        new GenericFactory(typeof(Nullable<>), typeof(NullableFactory<>)),

        new ArrayGenericFactory(),
        new GenericFactory(typeof(List<>), typeof(ListFactory<>)),
        new GenericFactory(typeof(Dictionary<,>), typeof(DictionaryFactory<,>)),
        new GenericFactory(typeof(Queue<>), typeof(QueueFactory<>)),
        new GenericFactory(typeof(Stack<>), typeof(StackFactory<>)),

        new GenericFactory(typeof(ConcurrentDictionary<,>), typeof(ConcurrentDictionaryFactory<,>)),
        new GenericFactory(typeof(ConcurrentQueue<>), typeof(ConcurrentQueueFactory<>)),
        new GenericFactory(typeof(ConcurrentBag<>), typeof(ConcurrentBagFactory<>)),
        new GenericFactory(typeof(ConcurrentStack<>), typeof(ConcurrentStackFactory<>)),

        new GenericFactory(typeof(IEnumerable<>), typeof(ListFactory<>)),
        new GenericFactory(typeof(IAsyncEnumerable<>), typeof(AsyncEnumerableFactory<>)),
        new GenericFactory(typeof(ICollection<>), typeof(ListFactory<>)),
        new GenericFactory(typeof(IList<>), typeof(ListFactory<>)),
        new GenericFactory(typeof(IDictionary<,>), typeof(DictionaryFactory<,>)),
        new GenericFactory(typeof(IQueryable<>), typeof(QueryableFactory<>)),

        new GenericFactory(typeof(IReadOnlyList<>), typeof(ListFactory<>)),
        new GenericFactory(typeof(IReadOnlyCollection<>), typeof(ListFactory<>)),
        new GenericFactory(typeof(IReadOnlyDictionary<,>), typeof(DictionaryFactory<,>)),

        new GenericFactory(typeof(ImmutableArray<>), typeof(ImmutableArrayFactory<>)),
        new GenericFactory(typeof(ImmutableList<>), typeof(ImmutableListFactory<>)),
        new GenericFactory(typeof(ImmutableDictionary<,>), typeof(ImmutableDictionaryFactory<,>)),
        new GenericFactory(typeof(ImmutableQueue<>), typeof(ImmutableQueueFactory<>)),

        new GenericFactory(typeof(IImmutableList<>), typeof(ImmutableListFactory<>)),
        new GenericFactory(typeof(IImmutableDictionary<,>), typeof(ImmutableDictionaryFactory<,>)),
        new GenericFactory(typeof(IImmutableQueue<>), typeof(ImmutableQueueFactory<>)),

#if NET        
        new GenericFactory(typeof(FrozenDictionary<,>), typeof(FrozenDictionaryFactory<,>)),
#endif
    };
}
