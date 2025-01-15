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

        Assert.IsTrue(fixture.Create<int[]>() is [1, 2, 3]);
    }

    [TestMethod]
    public void ListTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        Assert.IsTrue(fixture.Create<List<int>>() is [1, 2, 3]);
    }

    [TestMethod]
    public void IReadOnlyListTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        Assert.IsTrue(fixture.Create<IReadOnlyList<int>>() is [1, 2, 3]);
    }

    [TestMethod]
    public void IReadOnlyCollectionTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        Assert.IsTrue(fixture.Create<IReadOnlyCollection<int>>().ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void QueueTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        Assert.IsTrue(fixture.Create<Queue<int>>().ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void StackTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        Assert.IsTrue(fixture.Create<Stack<int>>().ToList() is [3, 2, 1]);
    }

    [TestMethod]
    public void IListTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        Assert.IsTrue(fixture.Create<IList<int>>() is [1, 2, 3]);
    }

    [TestMethod]
    public void IEnumerableTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        Assert.IsTrue(fixture.Create<IEnumerable<int>>().ToList() is [1, 2, 3]);
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

        Assert.IsTrue(fixture.Create<ICollection<int>>().ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void DictionaryTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3, 4, 5, 6)
            .Build();

        Assert.IsTrue(fixture.Create<Dictionary<int, int>>().ToList() is
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

        Assert.IsTrue(fixture.Create<IDictionary<int, int>>().ToList() is
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

        Assert.IsTrue(fixture.Create<IReadOnlyDictionary<int, int>>().ToList() is
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

        Assert.IsTrue(fixture.Create<ConcurrentDictionary<int, int>>().ToList() is
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

        Assert.IsTrue(fixture.Create<ImmutableArray<int>>() is [1, 2, 3]);
    }

    [TestMethod]
    public void ImmutableListTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        Assert.IsTrue(fixture.Create<ImmutableList<int>>() is [1, 2, 3]);
    }

    [TestMethod]
    public void ImmutableDictionaryTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3, 4, 5, 6)
            .Build();

        Assert.IsTrue(fixture.Create<ImmutableDictionary<int, int>>().ToList() is
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

        Assert.IsTrue(fixture.Create<ImmutableQueue<int>>().ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void IImmutableListTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        Assert.IsTrue(fixture.Create<IImmutableList<int>>().ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void IImmutableDictionaryTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3, 4, 5, 6)
            .Build();

        Assert.IsTrue(fixture.Create<IImmutableDictionary<int, int>>().ToList() is
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

        Assert.IsTrue(fixture.Create<IImmutableQueue<int>>().ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void ConcurrentBagTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        Assert.IsTrue(fixture.Create<ConcurrentBag<int>>().ToList() is [3, 2, 1]);
    }


    [TestMethod]
    public void ConcurrentQueueFactoryTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        Assert.IsTrue(fixture.Create<ConcurrentQueue<int>>().ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void ConcurrentStackTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        Assert.IsTrue(fixture.Create<ConcurrentStack<int>>().ToList() is [3, 2, 1]);
    }

#if NET    
    [TestMethod]
    public void FrozenDictionaryTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3, 4, 5, 6)
            .Build();

        Assert.IsTrue(fixture.Create<FrozenDictionary<int, int>>().ToList() is
            [
            { Key: 1, Value: 2 },
            { Key: 3, Value: 4 },
            { Key: 5, Value: 6 }
            ]);
    }
#endif
}
