namespace TestFixture.Factories.Collections;

internal sealed class StackFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return new Stack<T>(fixture.Create<T>(3));
    }
}
