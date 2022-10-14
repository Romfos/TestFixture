using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TestFixture.Factories;
using TestFixture.Factories.Collections;
using TestFixture.Factories.Collections.Immutable;
using TestFixture.Factories.Primitives;
using TestFixture.Factories.System;
using TestFixture.Providers;
using TestFixture.Services;

namespace TestFixture;

internal sealed class SharedFactoryContainer
{
    private static readonly IFactoryProvider[] providers =
    {
        new TypeFactoryProvider(typeof(IRandomService), typeof(RandomServiceFactory)),

        new TypeFactoryProvider(typeof(byte), typeof(ByteFactory)),
        new TypeFactoryProvider(typeof(sbyte), typeof(SByteFactory)),
        new TypeFactoryProvider(typeof(short), typeof(ShortFactory)),
        new TypeFactoryProvider(typeof(ushort), typeof(UShortFactory)),
        new TypeFactoryProvider(typeof(int), typeof(Int32Factory)),
        new TypeFactoryProvider(typeof(uint), typeof(UInt32Factory)),
        new TypeFactoryProvider(typeof(long), typeof(Int64Factory)),
        new TypeFactoryProvider(typeof(ulong), typeof(UInt64Factory)),
        new TypeFactoryProvider(typeof(float), typeof(FloatFactory)),
        new TypeFactoryProvider(typeof(double), typeof(DoubleFactory)),
        new TypeFactoryProvider(typeof(decimal), typeof(DecimalFactory)),

        new TypeFactoryProvider(typeof(char), typeof(CharFactory)),
        new TypeFactoryProvider(typeof(string), typeof(StringFactory)),
        new TypeFactoryProvider(typeof(bool), typeof(BooleanFactory)),

        new TypeFactoryProvider(typeof(Guid), typeof(GuidFactory)),
        new TypeFactoryProvider(typeof(Uri), typeof(UriFactory)),
        new TypeFactoryProvider(typeof(TimeSpan), typeof(TimeSpanFactory)),
        new TypeFactoryProvider(typeof(DateTime), typeof(DateTimeFactory)),
        new TypeFactoryProvider(typeof(DateTimeOffset), typeof(DateTimeOffsetFactory)),
#if NET6_0_OR_GREATER
        new TypeFactoryProvider(typeof(TimeOnly), typeof(TimeOnlyFactory)),
        new TypeFactoryProvider(typeof(DateOnly), typeof(DateOnlyFactory)),
#endif

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

    private static readonly ConcurrentDictionary<Type, IFactory> factories = new();

    public static IFactory Resolve(Type type)
    {
        return factories.GetOrAdd(type, static type => providers
            .Select(provider => provider.Resolve(type))
            .FirstOrDefault(x => x != null) ?? new DefaultClassFactory(type));
    }
}
