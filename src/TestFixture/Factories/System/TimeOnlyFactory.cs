using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

#if NET6_0_OR_GREATER

internal sealed class TimeOnlyFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return TimeOnly.FromDateTime(fixture.Create<IRandomService>().DateTime);
    }
}

#endif