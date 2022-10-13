using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class SByteFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return (sbyte)(fixture.Create<IRandomService>().Int32 % sbyte.MaxValue);
    }
}
