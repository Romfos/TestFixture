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
        var expected = DateTime.UtcNow;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<TimeSpan>().Should().Be(expected.TimeOfDay);
    }

    [TestMethod]
    public void BooleanTest()
    {
        var expected = 1;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<bool>().Should().BeTrue();
    }

    [TestMethod]
    public void UriTest()
    {
        var expected = Guid.NewGuid();
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<Uri>().Should().Be(new Uri($"http://{expected}.com"));
    }

    [TestMethod]
    public void ByteTest()
    {
        byte expected = 123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<byte>().Should().Be(expected);
    }

    [TestMethod]
    public void CharTest()
    {
        var expected = (char)123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<char>().Should().Be(expected);
    }

    [TestMethod]
    public void DecimalTest()
    {
        var expected = 123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<decimal>().Should().Be(expected);
    }

    [TestMethod]
    public void DoubleTest()
    {
        var expected = 123d;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<double>().Should().Be(expected);
    }

    [TestMethod]
    public void FloatTest()
    {
        var expected = 123d;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<float>().Should().Be((float)expected);
    }

    [TestMethod]
    public void SByteTest()
    {
        var expected = 123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<sbyte>().Should().Be((sbyte)expected);
    }

    [TestMethod]
    public void ShortTest()
    {
        var expected = 123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<short>().Should().Be((short)expected);
    }

    [TestMethod]
    public void UInt32Test()
    {
        var expected = 123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<uint>().Should().Be((uint)expected);
    }

    [TestMethod]
    public void UInt64Test()
    {
        var expected = 123L;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<ulong>().Should().Be((ulong)expected / 2);
    }

    [TestMethod]
    public void UInt16Test()
    {
        var expected = 123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<ushort>().Should().Be((ushort)expected);
    }

#if NET6_0_OR_GREATER

    [TestMethod]
    public void DateOnlyTest()
    {
        var expected = DateTime.UtcNow;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<DateOnly>().Should().Be(DateOnly.FromDateTime(expected));
    }

    [TestMethod]
    public void TimeOnlyTest()
    {
        var expected = DateTime.UtcNow;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        fixture.Create<TimeOnly>().Should().Be(TimeOnly.FromDateTime(expected));
    }

#endif
}
