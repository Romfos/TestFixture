using System;

namespace TestFixture.Factories.Primitives;

internal sealed class GuidFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return Guid.NewGuid();
    }
}

