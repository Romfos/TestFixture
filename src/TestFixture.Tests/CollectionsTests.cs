using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using TestFixture.Tests.Services;

namespace TestFixture.Tests;

[TestClass]
public sealed class CollectionsTests
{
    [TestMethod]
    public void ArrayTest()
    {
        var expected = new[] { 1, 2, 3 };
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        fixture.Create<int[]>().Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ListTest()
    {
        var expected = new List<int> { 1, 2, 3 };
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        fixture.Create<List<int>>().Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void QueueTest()
    {
        var expected = new List<int> { 1, 2, 3 };
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        fixture.Create<Queue<int>>().Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void StackTest()
    {
        var expected = new List<int> { 1, 2, 3 };
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        fixture.Create<Stack<int>>().Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void IListTest()
    {
        var expected = new List<int> { 1, 2, 3 };
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        fixture.Create<IList<int>>().Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void IEnumerableTest()
    {
        var expected = new List<int> { 1, 2, 3 };
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        fixture.Create<IEnumerable<int>>().Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public async Task IAsyncEnumerableEnumerableTest()
    {
        var expected = new List<int> { 1, 2, 3 };
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        var actual = await fixture.Create<IAsyncEnumerable<int>>().ToListAsync();

        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ICollectionTest()
    {
        var expected = new List<int> { 1, 2, 3 };
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        fixture.Create<ICollection<int>>().Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void DictionaryTest()
    {
        var expected = new Dictionary<int, int>
        {
            [1] = 2,
            [3] = 4,
            [5] = 6,
        };
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3, 4, 5, 6)
            .Build();

        fixture.Create<Dictionary<int, int>>().Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ConcurrentDictionary()
    {
        var expected = new Dictionary<int, int>
        {
            [1] = 2,
            [3] = 4,
            [5] = 6,
        };
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3, 4, 5, 6)
            .Build();

        fixture.Create<ConcurrentDictionary<int, int>>().Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ImmutableArrayTest()
    {
        var expected = ImmutableArray.Create(1, 2, 3);
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        fixture.Create<ImmutableArray<int>>().Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ImmutableListTest()
    {
        var expected = ImmutableList.Create(1, 2, 3);
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        fixture.Create<ImmutableList<int>>().Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ImmutableDictionaryTest()
    {
        var expected = ImmutableDictionary.Create<int, int>().Add(1, 2).Add(3, 4).Add(5, 6);
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3, 4, 5, 6)
            .Build();

        fixture.Create<ImmutableDictionary<int, int>>().Should().BeEquivalentTo(expected);
    }


    [TestMethod]
    public void ImmutableQueueTest()
    {
        var expected = ImmutableQueue.Create(1, 2, 3);
        var fixture = new TestFixtureBuilder()
            .With(1, 2, 3)
            .Build();

        fixture.Create<ImmutableQueue<int>>().Should().BeEquivalentTo(expected);
    }
}
