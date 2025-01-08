using System.Collections.Concurrent;

namespace TestFixture.Factories.Collections.Concurrent;

internal sealed class ConcurrentStackFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return new ConcurrentStack<T>(fixture.Create<T>(3));
    }
}
