using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using TestFixture.Tests.Services;

#if NET     
using System.Collections.Frozen;
#endif

namespace TestFixture.Tests;

[TestClass]
public sealed class CollectionsTests
{
    [TestMethod]
    public void ArrayTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<int[]>();

        Assert.IsTrue(actual is [1, 2, 3]);
    }

    [TestMethod]
    public void ListTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<List<int>>();

        Assert.IsTrue(actual is [1, 2, 3]);
    }

    [TestMethod]
    public void IReadOnlyListTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<IReadOnlyList<int>>();

        Assert.IsTrue(actual is [1, 2, 3]);
    }

    [TestMethod]
    public void IReadOnlyCollectionTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<IReadOnlyCollection<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void QueueTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<Queue<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void StackTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<Stack<int>>();

        Assert.IsTrue(actual.ToList() is [3, 2, 1]);
    }

    [TestMethod]
    public void IListTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<IList<int>>();

        Assert.IsTrue(actual is [1, 2, 3]);
    }

    [TestMethod]
    public void IEnumerableTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<IEnumerable<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public async Task IAsyncEnumerableEnumerableTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = await fixture.Create<IAsyncEnumerable<int>>().ToListAsync();

        Assert.IsTrue(actual is [1, 2, 3]);
    }

    [TestMethod]
    public void ICollectionTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<ICollection<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void DictionaryTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3, 4, 5, 6)
            .Build();

        var actual = fixture.Create<Dictionary<int, int>>();

        Assert.IsTrue(actual.ToList() is
            [
            { Key: 1, Value: 2 },
            { Key: 3, Value: 4 },
            { Key: 5, Value: 6 }
            ]);
    }

    [TestMethod]
    public void IDictionaryTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3, 4, 5, 6)
            .Build();

        var actual = fixture.Create<IDictionary<int, int>>();

        Assert.IsTrue(actual.ToList() is
            [
            { Key: 1, Value: 2 },
            { Key: 3, Value: 4 },
            { Key: 5, Value: 6 }
            ]);
    }

    [TestMethod]
    public void IReadOnlyDictionaryTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3, 4, 5, 6)
            .Build();

        var actual = fixture.Create<IReadOnlyDictionary<int, int>>();

        Assert.IsTrue(actual.ToList() is
            [
            { Key: 1, Value: 2 },
            { Key: 3, Value: 4 },
            { Key: 5, Value: 6 }
            ]);
    }

    [TestMethod]
    public void ConcurrentDictionary()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3, 4, 5, 6)
            .Build();

        var actual = fixture.Create<ConcurrentDictionary<int, int>>();

        Assert.IsTrue(actual.ToList() is
            [
            { Key: 1, Value: 2 },
            { Key: 3, Value: 4 },
            { Key: 5, Value: 6 }
            ]);
    }

    [TestMethod]
    public void ImmutableArrayTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<ImmutableArray<int>>();

        Assert.IsTrue(actual is [1, 2, 3]);
    }

    [TestMethod]
    public void ImmutableListTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<ImmutableList<int>>();

        Assert.IsTrue(actual is [1, 2, 3]);
    }

    [TestMethod]
    public void ImmutableDictionaryTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3, 4, 5, 6)
            .Build();

        var actual = fixture.Create<ImmutableDictionary<int, int>>();

        Assert.IsTrue(actual.ToList() is
            [
            { Key: 1, Value: 2 },
            { Key: 3, Value: 4 },
            { Key: 5, Value: 6 }
            ]);
    }

    [TestMethod]
    public void ImmutableQueueTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<ImmutableQueue<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void IImmutableListTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<IImmutableList<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void IImmutableDictionaryTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3, 4, 5, 6)
            .Build();

        var actual = fixture.Create<IImmutableDictionary<int, int>>();

        Assert.IsTrue(actual.ToList() is
            [
            { Key: 1, Value: 2 },
            { Key: 3, Value: 4 },
            { Key: 5, Value: 6 }
            ]);
    }

    [TestMethod]
    public void IImmutableQueueTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<IImmutableQueue<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void ConcurrentBagTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<ConcurrentBag<int>>();

        Assert.IsTrue(actual.ToList() is [3, 2, 1]);
    }

    [TestMethod]
    public void ConcurrentQueueFactoryTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<ConcurrentQueue<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void ConcurrentStackTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = fixture.Create<ConcurrentStack<int>>();

        Assert.IsTrue(actual.ToList() is [3, 2, 1]);
    }

#if NET    
    [TestMethod]
    public void FrozenDictionaryTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3, 4, 5, 6)
            .Build();

        var actual = fixture.Create<FrozenDictionary<int, int>>();

        Assert.IsTrue(actual.ToList() is
            [
            { Key: 1, Value: 2 },
            { Key: 3, Value: 4 },
            { Key: 5, Value: 6 }
            ]);
    }
#endif
}
