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
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<int[]>();

        Assert.IsTrue(actual is [1, 2, 3]);
    }

    [TestMethod]
    public void ListTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<List<int>>();

        Assert.IsTrue(actual is [1, 2, 3]);
    }

    [TestMethod]
    public void IReadOnlyListTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<IReadOnlyList<int>>();

        Assert.IsTrue(actual is [1, 2, 3]);
    }

    [TestMethod]
    public void IReadOnlyCollectionTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<IReadOnlyCollection<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void QueueTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<Queue<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void StackTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<Stack<int>>();

        Assert.IsTrue(actual.ToList() is [3, 2, 1]);
    }

    [TestMethod]
    public void IListTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<IList<int>>();

        Assert.IsTrue(actual is [1, 2, 3]);
    }

    [TestMethod]
    public void IEnumerableTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<IEnumerable<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void IQueryableTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<IQueryable<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }


    [TestMethod]
    public async Task IAsyncEnumerableEnumerableTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = await fixture.Create<IAsyncEnumerable<int>>().ToListAsync();

        Assert.IsTrue(actual is [1, 2, 3]);
    }

    [TestMethod]
    public void ICollectionTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<ICollection<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void DictionaryTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3, 4, 5, 6);

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
        var fixture = TestFixtureFactory.Create(1, 2, 3, 4, 5, 6);

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
        var fixture = TestFixtureFactory.Create(1, 2, 3, 4, 5, 6);

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
        var fixture = TestFixtureFactory.Create(1, 2, 3, 4, 5, 6);

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
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<ImmutableArray<int>>();

        Assert.IsTrue(actual is [1, 2, 3]);
    }

    [TestMethod]
    public void ImmutableListTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<ImmutableList<int>>();

        Assert.IsTrue(actual is [1, 2, 3]);
    }

    [TestMethod]
    public void ImmutableDictionaryTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3, 4, 5, 6);

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
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<ImmutableQueue<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void IImmutableListTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<IImmutableList<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void IImmutableDictionaryTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3, 4, 5, 6);

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
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<IImmutableQueue<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void ConcurrentBagTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<ConcurrentBag<int>>();

        Assert.IsTrue(actual.ToList() is [3, 2, 1]);
    }

    [TestMethod]
    public void ConcurrentQueueFactoryTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<ConcurrentQueue<int>>();

        Assert.IsTrue(actual.ToList() is [1, 2, 3]);
    }

    [TestMethod]
    public void ConcurrentStackTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);

        var actual = fixture.Create<ConcurrentStack<int>>();

        Assert.IsTrue(actual.ToList() is [3, 2, 1]);
    }

#if NET    
    [TestMethod]
    public void FrozenDictionaryTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3, 4, 5, 6);

        var actual = fixture.Create<FrozenDictionary<int, int>>();

        Assert.IsTrue(actual.ToList() is
            [
            { Key: 1, Value: 2 },
            { Key: 3, Value: 4 },
            { Key: 5, Value: 6 }
            ]);
    }
#endif

    [TestMethod]
    public void HashSetTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);
        var actual = fixture.Create<HashSet<int>>();
        CollectionAssert.AreEquivalent(new[] { 1, 2, 3 }, actual.ToArray());
    }

    [TestMethod]
    public void SortedSetTest()
    {
        var fixture = TestFixtureFactory.Create(3, 1, 2);
        var actual = fixture.Create<SortedSet<int>>();
        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, actual.ToArray());
    }

    [TestMethod]
    public void LinkedListTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);
        var actual = fixture.Create<LinkedList<int>>();
        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, actual.ToArray());
    }

    [TestMethod]
    public void SortedDictionaryTest()
    {
        var fixture = TestFixtureFactory.Create(3, 6, 1, 2, 5, 4);
        var actual = fixture.Create<SortedDictionary<int, int>>();
        CollectionAssert.AreEqual(new[] { (1, 2), (3, 6), (5, 4) }, actual.Select(kv => (kv.Key, kv.Value)).ToArray());
    }

    [TestMethod]
    public void SortedListTest()
    {
        var fixture = TestFixtureFactory.Create(3, 6, 1, 2, 5, 4);
        var actual = fixture.Create<SortedList<int, int>>();
        CollectionAssert.AreEqual(new[] { (1, 2), (3, 6), (5, 4) }, actual.Select(kv => (kv.Key, kv.Value)).ToArray());
    }
}
