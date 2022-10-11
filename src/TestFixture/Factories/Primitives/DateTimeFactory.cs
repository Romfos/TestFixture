using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class DateTimeFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<IRandomService>().DateTime;
    }
}

