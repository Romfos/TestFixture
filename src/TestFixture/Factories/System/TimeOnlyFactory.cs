#if NET

using TestFixture.Services;

namespace TestFixture.Factories.System;

internal sealed class TimeOnlyFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return TimeOnly.FromDateTime(fixture.Create<IRandomService>().DateTime);
    }
}

#endif