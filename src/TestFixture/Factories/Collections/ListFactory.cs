using System.Linq;

namespace TestFixture.Factories.Collections;

internal sealed class ListFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<T>(3).ToList();
    }
}
