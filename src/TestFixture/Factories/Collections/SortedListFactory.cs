namespace TestFixture.Factories.Collections;

internal sealed class SortedListFactory<TKey, TValue> : IFactory
    where TKey : notnull
{
    public object Create(Fixture fixture)
    {
        var pairs = fixture.Create<KeyValuePair<TKey, TValue>>(3);
        var sortedList = new SortedList<TKey, TValue>();
        foreach (var pair in pairs)
        {
            sortedList[pair.Key] = pair.Value;
        }
        return sortedList;
    }
}
