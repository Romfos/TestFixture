#if NET
using System.Collections.Frozen;

namespace TestFixture.Factories.Collections.Frozen;

internal sealed class FrozenSetFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return fixture.Create<T>(3).ToFrozenSet();
    }
}
#endif
