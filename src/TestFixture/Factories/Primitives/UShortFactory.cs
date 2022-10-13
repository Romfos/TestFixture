using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class UShortFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return (ushort)(fixture.Create<IRandomService>().Int32 % ushort.MaxValue);
    }
}
