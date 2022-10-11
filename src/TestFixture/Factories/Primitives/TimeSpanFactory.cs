using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class TimeSpanFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<IRandomService>().TimeSpan;
    }
}

