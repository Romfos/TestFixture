namespace TestFixture.Factories.Collections;

internal sealed class SortedSetFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return new SortedSet<T>(fixture.Create<T>(3));
    }
}
