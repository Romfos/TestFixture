namespace TestFixture.Factories;

internal sealed class StringFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return $"string_Guid.NewGuid()";
    }
}

