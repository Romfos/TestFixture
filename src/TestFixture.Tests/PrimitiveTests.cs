using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestFixture.Tests.Services;

namespace TestFixture.Tests;

[TestClass]
public sealed class PrimitiveTypesFactoryTests
{
    [TestMethod]
    public void Int32Test()
    {
        var expected = 123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<int>().Should().Be(expected);
    }

    [TestMethod]
    public void GuidTest()
    {
        var expected = System.Guid.NewGuid();
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<Guid>().Should().Be(expected);
    }

    [TestMethod]
    public void StringTest()
    {
        var expected = "abcd";
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<string>().Should().Be(expected);
    }

    [TestMethod]
    public void Int64Test()
    {
        var expected = long.MinValue;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<long>().Should().Be(expected);
    }

    [TestMethod]
    public void DateTimeTest()
    {
        var expected = DateTime.UtcNow;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<DateTime>().Should().Be(expected);
    }

    [TestMethod]
    public void TimeSpanTest()
    {
        var expected = DateTime.UtcNow.TimeOfDay;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<TimeSpan>().Should().Be(expected);
    }
}
