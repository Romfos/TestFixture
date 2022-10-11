using TestFixture.Services;

namespace TestFixture.Factories.Primitives;

internal sealed class BooleanFactory : IFactory
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<IRandomService>().Int32 % 2 == 1;
    }
}
