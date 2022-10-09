using System;

namespace TestFixture.Factories.Primitives;

internal sealed class StringFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return $"string_{Guid.NewGuid()}";
    }
}

