using System;
using TestFixture.Services;

namespace TestFixture.Factories.System;

internal sealed class DateTimeOffsetFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return new DateTimeOffset(fixture.Create<IRandomService>().DateTime);
    }
}
