namespace TestFixture.Factories.Collections;

internal sealed class HashSetFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return new HashSet<T>(fixture.Create<T>(3));
    }
}
