using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        Assert.AreEqual(expected, fixture.Create<int>());
    }

    [TestMethod]
    public void GuidTest()
    {
        var expected = Guid.NewGuid();
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual(expected, fixture.Create<Guid>());
    }

    [TestMethod]
    public void StringTest()
    {
        var expected = "abcd";
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual(expected, fixture.Create<string>());
    }

    [TestMethod]
    public void Int64Test()
    {
        var expected = long.MinValue;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual(expected, fixture.Create<long>());
    }

    [TestMethod]
    public void DateTimeTest()
    {
        var expected = DateTime.UtcNow;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual(expected, fixture.Create<DateTime>());
    }

    [TestMethod]
    public void TimeSpanTest()
    {
        var expected = DateTime.UtcNow;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual(expected.TimeOfDay, fixture.Create<TimeSpan>());
    }

    [TestMethod]
    public void BooleanTest()
    {
        var expected = 1;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.IsTrue(fixture.Create<bool>());
    }

    [TestMethod]
    public void UriTest()
    {
        var expected = Guid.NewGuid();
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual(new Uri($"http://{expected}.com"), fixture.Create<Uri>());
    }

    [TestMethod]
    public void ByteTest()
    {
        byte expected = 123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual(expected, fixture.Create<byte>());
    }

    [TestMethod]
    public void CharTest()
    {
        var expected = (char)123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual(expected, fixture.Create<char>());
    }

    [TestMethod]
    public void DecimalTest()
    {
        var expected = 123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual(expected, fixture.Create<decimal>());
    }

    [TestMethod]
    public void DoubleTest()
    {
        var expected = 123d;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual(expected, fixture.Create<double>());
    }

    [TestMethod]
    public void FloatTest()
    {
        var expected = 123d;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual((float)expected, fixture.Create<float>());
    }

    [TestMethod]
    public void SByteTest()
    {
        var expected = 123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual((sbyte)expected, fixture.Create<sbyte>());
    }

    [TestMethod]
    public void ShortTest()
    {
        var expected = 123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual((short)expected, fixture.Create<short>());
    }

    [TestMethod]
    public void UInt32Test()
    {
        var expected = 123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual((uint)expected, fixture.Create<uint>());
    }

    [TestMethod]
    public void UInt64Test()
    {
        var expected = 123L;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual((ulong)expected / 2, fixture.Create<ulong>());
    }

    [TestMethod]
    public void UInt16Test()
    {
        var expected = 123;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual((ushort)expected, fixture.Create<ushort>());
    }

#if NET

    [TestMethod]
    public void DateOnlyTest()
    {
        var expected = DateTime.UtcNow;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual(DateOnly.FromDateTime(expected), fixture.Create<DateOnly>());
    }

    [TestMethod]
    public void TimeOnlyTest()
    {
        var expected = DateTime.UtcNow;
        var fixture = new TestFixtureBuilder()
            .With(expected)
            .Build();

        Assert.AreEqual(TimeOnly.FromDateTime(expected), fixture.Create<TimeOnly>());
    }

#endif
}
