using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace TestFixture.Tests;

[TestClass]
public sealed class CollectionsFactoryTests
{
    private readonly Fixture fixture = new Fixture();

    [TestMethod]
    public void Array()
    {
        fixture.Create<string[]>();
    }

    [TestMethod]
    public void List()
    {
        fixture.Create<List<string>>();
    }

    [TestMethod]
    public void Dictionary()
    {
        fixture.Create<Dictionary<int, string>>();
    }

    [TestMethod]
    public void ImmutableArray()
    {
        fixture.Create<ImmutableArray<string>>();
    }

    [TestMethod]
    public void ImmutableList()
    {
        fixture.Create<ImmutableList<string>>();
    }

    [TestMethod]
    public void ImmutableDictionary()
    {
        fixture.Create<ImmutableDictionary<int, string>>();
    }
}
