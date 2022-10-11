using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class StringFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<IRandomService>().String;
    }
}

