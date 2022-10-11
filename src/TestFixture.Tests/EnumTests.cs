using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        var fixture = new TestFixtureBuilder()
            .With(2)
            .Build();

        fixture.Create<TestEnum>().Should().Be(TestEnum.C);
    }
}
