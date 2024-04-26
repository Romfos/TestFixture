using System.Collections.Concurrent;

namespace TestFixture.Factories.Collections.Concurrent;

internal sealed class ConcurrentDictionaryFactory<TKey, TValue> : IFactory
    where TKey : notnull
{
    public object Create(Fixture fixture)
    {
        return new ConcurrentDictionary<TKey, TValue>(fixture.Create<KeyValuePair<TKey, TValue>>(3));
    }
}
