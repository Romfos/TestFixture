using System.Collections.Generic;
using System.Linq;

namespace TestFixture.Factories.Collections;

internal sealed class DictionaryFactory<TKey, TValue> : IFactory
    where TKey : notnull
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<KeyValuePair<TKey, TValue>>(3).ToDictionary(x => x.Key, x => x.Value);
    }
}
