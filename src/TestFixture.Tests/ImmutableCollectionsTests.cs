using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;
using TestFixture.Tests.Services;

namespace TestFixture.Tests;

[TestClass]
public sealed class ImmutableCollectionsTests
{
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
    public void ImmutableHashSetTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);
        var actual = fixture.Create<ImmutableHashSet<int>>();
        CollectionAssert.AreEquivalent(new[] { 1, 2, 3 }, actual.ToArray());
    }

    [TestMethod]
    public void ImmutableSortedSetTest()
    {
        var fixture = TestFixtureFactory.Create(3, 1, 2);
        var actual = fixture.Create<ImmutableSortedSet<int>>();
        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, actual.ToArray());
    }

    [TestMethod]
    public void ImmutableSortedDictionaryTest()
    {
        var fixture = TestFixtureFactory.Create(3, 6, 1, 2, 5, 4);
        var actual = fixture.Create<ImmutableSortedDictionary<int, int>>();
        Assert.IsTrue(actual.ToList() is
            [
            { Key: 1, Value: 2 },
            { Key: 3, Value: 6 },
            { Key: 5, Value: 4 }
            ]);
    }

    [TestMethod]
    public void ImmutableStackTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);
        var actual = fixture.Create<ImmutableStack<int>>();
        CollectionAssert.AreEqual(new[] { 3, 2, 1 }, actual.ToArray());
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
}
