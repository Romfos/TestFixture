using System;
using TestFixture.Services;

namespace TestFixture.Factories.System;

#if NET6_0_OR_GREATER

internal sealed class DateOnlyFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return DateOnly.FromDateTime(fixture.Create<IRandomService>().DateTime);
    }
}

#endif