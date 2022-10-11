using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFixture.Tests.Services;

namespace TestFixture.Tests;

[TestClass]
public sealed class NullableTests
{
    [TestMethod]
    public void NullableTest()
    {
        var expected = 123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<int?>().Should().Be(new int?(expected));
    }
}
