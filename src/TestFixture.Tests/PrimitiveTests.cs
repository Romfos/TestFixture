using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestFixture.Tests;

[TestClass]
public sealed class PrimitiveTests
{
    private readonly Fixture fixture = new Fixture();

    [TestMethod]
    public void Int32()
    {
        fixture.Create<int>();
    }

    [TestMethod]
    public void Guid()
    {
        fixture.Create<Guid>();
    }

    [TestMethod]
    public void String()
    {
        fixture.Create<string>();
    }
}
