namespace TestFixture.Factories.Collections;

internal sealed class QueryableFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<T>(3).AsQueryable();
    }
}