using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class UInt32Factory : IFactory
{
    public object Create(Fixture fixture)
    {
        return (uint)(fixture.Create<IRandomService>().Int32 % uint.MaxValue);
    }
}
