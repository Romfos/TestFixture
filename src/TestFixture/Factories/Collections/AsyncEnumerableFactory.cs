using System.Collections.Generic;
using System.Linq;

namespace TestFixture.Factories.Collections;

internal sealed class AsyncEnumerableFactory<T> : IFactory
{
    public object Create(Fixture fixture)
    {
        return ConvertToAsyncEnumerable(fixture.Create<T>(3).ToList());
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    private async IAsyncEnumerable<T> ConvertToAsyncEnumerable(List<T> items)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}
