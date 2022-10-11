using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class Int64Factory : IFactory
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<IRandomService>().Int64;
    }
}
