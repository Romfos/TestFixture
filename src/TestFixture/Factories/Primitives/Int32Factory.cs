using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class Int32Factory : IFactory
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<IRandomService>().Int32;
    }
}
