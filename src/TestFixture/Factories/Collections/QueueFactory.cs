namespace TestFixture.Factories.Collections;

internal sealed class QueueFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return new Queue<T>(fixture.Create<T>(3));
    }
}
