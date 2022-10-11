using System.Collections.Generic;
using System.Collections.Immutable;

namespace TestFixture.Factories.Collections.Immutable;

internal sealed class ImmutableDictionaryFactory<TKey, TValue> : IFactory
    where TKey : notnull
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<KeyValuePair<TKey, TValue>>(3).ToImmutableDictionary(x => x.Key, x => x.Value);
    }
}
