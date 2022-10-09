namespace TestFixture.Factories;

internal sealed class StringFactory : IFactory
{
    public object Create(Fixture fixture) => $"string_Guid.NewGuid()";
}

