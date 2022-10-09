using System;

namespace TestFixture.Factories;

internal sealed class GuidFactory : IFactory
{
    public object Create(Fixture fixture) => Guid.NewGuid();
}

