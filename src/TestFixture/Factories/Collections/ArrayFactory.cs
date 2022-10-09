using System.Linq;

namespace TestFixture.Factories.Collections;

internal sealed class ArrayFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<T>(3).ToArray();
    }
}
