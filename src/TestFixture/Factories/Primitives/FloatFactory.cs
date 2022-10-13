using System;
using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class FloatFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return (float)Math.Round(fixture.Create<IRandomService>().Double, 10);
    }
}
