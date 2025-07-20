#if NET
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Frozen;
using TestFixture.Tests.Services;

namespace TestFixture.Tests;

[TestClass]
public sealed class FrozenCollectionsTests
{
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

    [TestMethod]
    public void FrozenSetTest()
    {
        var fixture = TestFixtureFactory.Create(1, 2, 3);
        var actual = fixture.Create<FrozenSet<int>>();
        CollectionAssert.AreEquivalent(new[] { 1, 2, 3 }, actual);
    }
}
#endif
