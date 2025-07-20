namespace TestFixture.Factories.Collections;

internal sealed class SortedDictionaryFactory<TKey, TValue> : IFactory
    where TKey : notnull
{
    public object Create(Fixture fixture)
    {
        var pairs = fixture.Create<KeyValuePair<TKey, TValue>>(3);
        var dict = new SortedDictionary<TKey, TValue>();
        foreach (var pair in pairs)
        {
            dict[pair.Key] = pair.Value;
        }
        return dict;
    }
}
