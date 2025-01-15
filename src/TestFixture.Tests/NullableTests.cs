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

        Assert.IsTrue(fixture.Create<int?>() is 123);
    }
}
