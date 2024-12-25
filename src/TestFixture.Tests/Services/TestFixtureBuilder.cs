using NSubstitute;
using TestFixture.Services;

namespace TestFixture.Tests.Services;

internal sealed class TestFixtureBuilder
{
    private readonly IRandomService substitute = Substitute.For<IRandomService>();

    public TestFixtureBuilder With(params IEnumerable<int> values)
    {
        var queue = new Queue<int>(values);
        substitute.Int32.Returns(x => queue.Dequeue());
        return this;
    }

    public TestFixtureBuilder With(params IEnumerable<double> values)
    {
        var queue = new Queue<double>(values);
        substitute.Double.Returns(x => queue.Dequeue());
        return this;
    }

    public TestFixtureBuilder With(params IEnumerable<Guid> values)
    {
        var queue = new Queue<Guid>(values);
        substitute.Guid.Returns(x => queue.Dequeue());
        return this;
    }

    public TestFixtureBuilder With(params IEnumerable<string> values)
    {
        var queue = new Queue<string>(values);
        substitute.String.Returns(x => queue.Dequeue());
        return this;
    }

    public TestFixtureBuilder With(params IEnumerable<long> values)
    {
        var queue = new Queue<long>(values);
        substitute.Int64.Returns(x => queue.Dequeue());
        return this;
    }

    public TestFixtureBuilder With(params IEnumerable<DateTime> values)
    {
        var queue = new Queue<DateTime>(values);
        substitute.DateTime.Returns(x => queue.Dequeue());
        return this;
    }

    public Fixture Build()
    {
        var fixture = new Fixture();
        fixture.RegisterInstance(substitute);
        return fixture;
    }
}
