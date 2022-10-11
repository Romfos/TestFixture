using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.Immutable;
using TestFixture.Tests.Services;

namespace TestFixture.Tests;

[TestClass]
public sealed class CollectionsFactoryTests
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
}
