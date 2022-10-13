using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class CharFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return (char)(fixture.Create<IRandomService>().Int32 % 255);
    }
}
