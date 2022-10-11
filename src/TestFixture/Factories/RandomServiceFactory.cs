using TestFixture.Services;

namespace TestFixture.Factories;

public sealed class RandomServiceFactory : IFactory
{
    private readonly RandomService randomService = new();

    public object Create(Fixture fixture)
    {
        return randomService;
    }
}
