using FluentAssertions;
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
            a.Should().Be(1);
            b.Should().Be(2);
        }
    }

    [TestMethod]
    public void ClassWithSingleConstructor()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2)
            .Build();

        fixture.Create<Class1>();
    }

    private class Class2
    {
        public Class2(int a, int b)
        {
            a.Should().Be(1);
            b.Should().Be(2);
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

        fixture.Create<Class2>();
    }

    private class Class3
    {
        public Class3(int a, Class4 nestedClass)
        {
            a.Should().Be(1);
            nestedClass.Should().NotBeNull();
        }
    }

    private class Class4
    {
        public Class4(int b)
        {
            b.Should().Be(2);
        }
    }

    [TestMethod]
    public void ClassWithNestedClass()
    {
        var fixture = new TestFixtureBuilder()
            .With(1, 2)
            .Build();

        fixture.Create<Class3>();
    }

    public class Class5
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

        fixture.Create<Class5>().Should().BeEquivalentTo(expected);
    }
}
