using System.Collections.Immutable;

namespace TestFixture.Factories.Collections.Immutable;

internal sealed class ImmutableSortedDictionaryFactory<TKey, TValue> : IFactory
    where TKey : notnull
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<KeyValuePair<TKey, TValue>>(3).ToImmutableSortedDictionary(x => x.Key, x => x.Value);
    }
}
