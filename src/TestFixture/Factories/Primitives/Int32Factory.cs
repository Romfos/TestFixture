using System;

namespace TestFixture.Factories.Primitives;

internal sealed class Int32Factory : IFactory
{
    private readonly Random random = new();

    public object Create(Fixture fixture)
    {
        return random.Next();
    }
}
