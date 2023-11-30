namespace TestFixture.Factories.System;

internal sealed class UriFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return new Uri($"http://{fixture.Create<Guid>()}.com");
    }
}
