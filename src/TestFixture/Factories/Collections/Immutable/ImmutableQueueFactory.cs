using System.Collections.Immutable;

namespace TestFixture.Factories.Collections.Immutable;

internal sealed class ImmutableQueueFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return ImmutableQueue.CreateRange(fixture.Create<T>(3));
    }
}
