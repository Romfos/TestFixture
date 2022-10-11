using Moq;
using System;
using System.Collections.Generic;
using TestFixture.Services;

namespace TestFixture.Tests.Services;

internal sealed class TestFixtureBuilder
{
    private readonly Mock<IRandomService> mock = new();

    public TestFixtureBuilder With(params int[] values)
    {
        var queue = new Queue<int>(values);
        mock.SetupGet(x => x.Int32).Returns(() => queue.Dequeue());
        return this;
    }

    public TestFixtureBuilder With(params Guid[] values)
    {
        var queue = new Queue<Guid>(values);
        mock.SetupGet(x => x.Guid).Returns(() => queue.Dequeue());
        return this;
    }

    public TestFixtureBuilder With(params string[] values)
    {
        var queue = new Queue<string>(values);
        mock.SetupGet(x => x.String).Returns(() => queue.Dequeue());
        return this;
    }

    public TestFixtureBuilder With(params long[] values)
    {
        var queue = new Queue<long>(values);
        mock.SetupGet(x => x.Int64).Returns(() => queue.Dequeue());
        return this;
    }

    public TestFixtureBuilder With(params DateTime[] values)
    {
        var queue = new Queue<DateTime>(values);
        mock.SetupGet(x => x.DateTime).Returns(() => queue.Dequeue());
        return this;
    }

    public TestFixtureBuilder With(params TimeSpan[] values)
    {
        var queue = new Queue<TimeSpan>(values);
        mock.SetupGet(x => x.TimeSpan).Returns(() => queue.Dequeue());
        return this;
    }

    public Fixture Build()
    {
        var mockRandomServiceFactory = new MockRandomServiceFactory(mock.Object);
        var mockFactoryProvider = new MockFactoryProvider(mockRandomServiceFactory);
        return new Fixture(new[] { mockFactoryProvider });
    }
}
