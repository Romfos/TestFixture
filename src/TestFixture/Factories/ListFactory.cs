using System.Linq;

namespace TestFixture.Factories;

internal sealed class ListFactory<T> : IFactory
{
    public object Create(Fixture fixture) => fixture.Create<T>(3).ToList();
}
