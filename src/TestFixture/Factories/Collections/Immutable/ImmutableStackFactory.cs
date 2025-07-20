using System.Collections.Immutable;

namespace TestFixture.Factories.Collections.Immutable;

internal sealed class ImmutableStackFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return ImmutableStack.CreateRange(fixture.Create<T>(3));
    }
}
