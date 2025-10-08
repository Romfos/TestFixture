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

        Assert.AreEqual(123, actual);
    }
}
