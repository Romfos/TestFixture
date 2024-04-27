#if NET8_0_OR_GREATER
using System.Collections.Frozen;

namespace TestFixture.Factories.Collections.Frozen;

internal sealed class FrozenDictionaryFactory<TKey, TValue> : IFactory
    where TKey : notnull
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<KeyValuePair<TKey, TValue>>(3).ToFrozenDictionary(x => x.Key, x => x.Value);
    }
}
#endif