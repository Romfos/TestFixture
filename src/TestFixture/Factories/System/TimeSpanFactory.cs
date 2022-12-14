using TestFixture.Services;

namespace TestFixture.Factories.System;

internal sealed class TimeSpanFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<IRandomService>().DateTime.TimeOfDay;
    }
}

