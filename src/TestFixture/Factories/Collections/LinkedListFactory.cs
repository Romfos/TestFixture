namespace TestFixture.Factories.Collections;

internal sealed class LinkedListFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return new LinkedList<T>(fixture.Create<T>(3));
    }
}
