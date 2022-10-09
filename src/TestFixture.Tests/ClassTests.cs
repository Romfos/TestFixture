using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFixture.Tests;

[TestClass]
public sealed class ClassTests
{
    private readonly Fixture fixture = new Fixture();

    private class Class1
    {
        public Class1(int A, string B)
        {
        }
    }

    [TestMethod]
    public void ClassWithSingleConstructor()
    {
        fixture.Create<Class1>();
    }

    private class Class2
    {
        public Class2(int A, string B)
        {
        }


        public Class2(int A)
        {
        }
    }

    [TestMethod]
    public void ClassWithMultipleConstructor()
    {
        fixture.Create<Class2>();
    }

    private class Class3
    {
        public Class3(int A, Class4 nestedClass)
        {
        }
    }

    private class Class4
    {
        public Class4(int A)
        {
        }
    }

    [TestMethod]
    public void ClassWithNestedClass()
    {
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
        var actual = fixture.Create<Class5>();
        Assert.IsNotNull(actual.Foo);
        Assert.IsNull(actual.Bar);
    }
}
