using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class ByteFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return (byte)(fixture.Create<IRandomService>().Int32 % 255);
    }
}
