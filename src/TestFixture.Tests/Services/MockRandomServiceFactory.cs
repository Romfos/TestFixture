using TestFixture.Factories;
using TestFixture.Services;

namespace TestFixture.Tests.Services;

internal sealed class MockRandomServiceFactory : IFactory
{
    private readonly IRandomService randomService;

    public MockRandomServiceFactory(IRandomService randomService)
    {
        this.randomService = randomService;
    }

    public object Create(Fixture fixture)
    {
        return randomService;
    }
}
