using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
}
