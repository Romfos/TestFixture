using System;

namespace TestFixture.Factories;

internal sealed class StringFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return $"string_{Guid.NewGuid()}";
    }
}

