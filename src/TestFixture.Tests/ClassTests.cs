using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFixture.Tests.Services;

namespace TestFixture.Tests;

[TestClass]
public sealed class ClassTests
{
    private class Class1
    {
        public Class1(int a, int b)
        {
            Assert.AreEqual(1, a);
            Assert.AreEqual(2, b);
        }
    }

    [TestMethod]
    public void ClassWithSingleConstructor()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2)
            .Build();

        var actual = fixture.Create<Class1>();
    }

    private class Class2
    {
        public Class2(int a, int b)
        {
            Assert.AreEqual(1, a);
            Assert.AreEqual(2, b);
        }

        public Class2(int a)
        {
            throw new Exception();
        }
    }

    [TestMethod]
    public void ClassWithMultipleConstructor()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2)
            .Build();

        var actual = fixture.Create<Class2>();
    }

    private class Class3
    {
        public Class3(int a, Class4 nestedClass)
        {
            Assert.AreEqual(1, a);
            Assert.IsNotNull(nestedClass);
        }
    }

    private class Class4
    {
        public Class4(int b)
        {
            Assert.AreEqual(2, b);
        }
    }

    [TestMethod]
    public void ClassWithNestedClass()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2)
            .Build();

        var actual = fixture.Create<Class3>();
    }

    public record Class5
    {
        public string? Foo { get; set; }
        public string? Bar { get; }
    }

    [TestMethod]
    public void ClassWithProperties()
    {
        var expected = new Class5
        {
            Foo = "x"
        };

        var fixture = new TestFixtureBuilder()
            .With("x")
            .Build();

        var actual = fixture.Create<Class5>();

        Assert.AreEqual(expected, actual);
    }
}

