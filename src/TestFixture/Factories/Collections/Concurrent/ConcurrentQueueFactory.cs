using System.Collections.Concurrent;

namespace TestFixture.Factories.Collections.Concurrent;

internal sealed class ConcurrentQueueFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return new ConcurrentQueue<T>(fixture.Create<T>(3));
    }
}
