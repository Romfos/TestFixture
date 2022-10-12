using System;

namespace TestFixture.Factories.Primitives;

internal sealed class UriFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return new Uri($"http://{fixture.Create<Guid>()}.com");
    }
}
