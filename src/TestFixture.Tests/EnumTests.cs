using TestFixture.Tests.Services;

namespace TestFixture.Tests;

[TestClass]
public sealed class EnumTests
{
    internal enum TestEnum
    {
        A = 1,
        B = 2,
        C = 3
    }

    [TestMethod]
    public void EnumTest()
    {
        var fixture = TestFixtureFactory.Create(2);

        var actual = fixture.Create<TestEnum>();

        Assert.AreEqual(TestEnum.C, actual);
    }
}
