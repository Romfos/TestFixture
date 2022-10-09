using System.Linq;

namespace TestFixture.Factories;

internal sealed class ArrayFactory<T> : IFactory
{
    public object Create(Fixture fixture) => fixture.Create<T>(3).ToArray();
}
