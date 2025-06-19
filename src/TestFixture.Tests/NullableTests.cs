using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFixture.Tests.Services;

namespace TestFixture.Tests;

[TestClass]
public sealed class NullableTests
{
    [TestMethod]
    public void NullableTest()
    {
        var fixture = TestFixtureFactory.Create(123);

        var actual = fixture.Create<int?>();

        Assert.IsTrue(actual is 123);
    }
}
