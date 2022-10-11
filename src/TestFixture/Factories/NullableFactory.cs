namespace TestFixture.Factories;

internal sealed class NullableFactory<T> : IFactory
    where T : struct
{
    public object Create(Fixture fixture)
    {
        return new T?(fixture.Create<T>());
    }
}
