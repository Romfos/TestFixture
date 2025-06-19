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
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<int>();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GuidTest()
    {
        var expected = Guid.NewGuid();
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<Guid>();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void StringTest()
    {
        var expected = "abcd";
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<string>();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Int64Test()
    {
        var expected = long.MinValue;
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<long>();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DateTimeTest()
    {
        var expected = DateTime.UtcNow;
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<DateTime>();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TimeSpanTest()
    {
        var expected = DateTime.UtcNow;
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<TimeSpan>();

        Assert.AreEqual(expected.TimeOfDay, actual);
    }

    [TestMethod]
    public void BooleanTest()
    {
        var expected = 1;
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<bool>();

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void UriTest()
    {
        var expected = Guid.NewGuid();
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<Uri>();

        Assert.AreEqual(new Uri($"http://{expected}.com"), actual);
    }

    [TestMethod]
    public void ByteTest()
    {
        byte expected = 123;
        var fixture = TestFixtureFactory.Create((int)expected);
        var actual = fixture.Create<byte>();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void CharTest()
    {
        var expected = (char)123;
        var fixture = TestFixtureFactory.Create((int)expected);
        var actual = fixture.Create<char>();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DecimalTest()
    {
        var expected = 123;
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<decimal>();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DoubleTest()
    {
        var expected = 123d;
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<double>();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FloatTest()
    {
        var expected = 123d;
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<float>();

        Assert.AreEqual((float)expected, actual);
    }

    [TestMethod]
    public void SByteTest()
    {
        var expected = 123;
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<sbyte>();

        Assert.AreEqual((sbyte)expected, actual);
    }

    [TestMethod]
    public void ShortTest()
    {
        var expected = 123;
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<short>();

        Assert.AreEqual((short)expected, actual);
    }

    [TestMethod]
    public void UInt32Test()
    {
        var expected = 123;
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<uint>();

        Assert.AreEqual((uint)expected, actual);
    }

    [TestMethod]
    public void UInt64Test()
    {
        var expected = 123L;
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<ulong>();

        Assert.AreEqual((ulong)expected / 2, actual);
    }

    [TestMethod]
    public void UInt16Test()
    {
        var expected = 123;
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<ushort>();

        Assert.AreEqual((ushort)expected, actual);
    }

#if NET

    [TestMethod]
    public void DateOnlyTest()
    {
        var expected = DateTime.UtcNow;
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<DateOnly>();

        Assert.AreEqual(DateOnly.FromDateTime(expected), actual);
    }

    [TestMethod]
    public void TimeOnlyTest()
    {
        var expected = DateTime.UtcNow;
        var fixture = TestFixtureFactory.Create(expected);
        var actual = fixture.Create<TimeOnly>();

        Assert.AreEqual(TimeOnly.FromDateTime(expected), actual);
    }

#endif
}
