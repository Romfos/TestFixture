using System.Collections.Concurrent;

namespace TestFixture.Factories.Collections.Concurrent;

internal sealed class ConcurrentBagFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return new ConcurrentBag<T>(fixture.Create<T>(3));
    }
}
