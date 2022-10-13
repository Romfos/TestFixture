using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class DoubleFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<IRandomService>().Double;
    }
}
