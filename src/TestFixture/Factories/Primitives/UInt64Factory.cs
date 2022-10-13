using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class UInt64Factory : IFactory
{
    public object Create(Fixture fixture)
    {
        return (ulong)(fixture.Create<IRandomService>().Int64 / 2);
    }
}
