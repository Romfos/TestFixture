using System.Collections.Immutable;

namespace TestFixture.Factories.Collections.Immutable;

internal sealed class ImmutableSortedSetFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<T>(3).ToImmutableSortedSet();
    }
}
