using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFixture.Tests.Services;

namespace TestFixture.Tests;

[TestClass]
public sealed class NullableTests
{
    [TestMethod]
    public void NullableTest()
    {
        var fixture = new TestFixtureBuilder()
            .With(123)
            .Build();

        var actual = fixture.Create<int?>();

        Assert.IsTrue(actual is 123);
    }
}
