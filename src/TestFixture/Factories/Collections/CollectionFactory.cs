using System.Collections.ObjectModel;

namespace TestFixture.Factories.Collections;

internal sealed class CollectionFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return new Collection<T>(fixture.Create<T>(3).ToList());
    }
}