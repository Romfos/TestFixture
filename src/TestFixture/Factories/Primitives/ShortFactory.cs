using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class ShortFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return (short)(fixture.Create<IRandomService>().Int32 % short.MaxValue);
    }
}
