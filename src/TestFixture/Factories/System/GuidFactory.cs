using TestFixture.Services;

namespace TestFixture.Factories.System;

internal sealed class GuidFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<IRandomService>().Guid;
    }
}

