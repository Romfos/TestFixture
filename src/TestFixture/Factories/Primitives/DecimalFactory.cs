using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class DecimalFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return (decimal)fixture.Create<IRandomService>().Int32;
    }
}
