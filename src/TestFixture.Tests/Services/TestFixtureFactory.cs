using TestFixture.Services;

namespace TestFixture.Tests.Services;

internal static class TestFixtureFactory
{
    private sealed class TestRandomService(IEnumerable<object> values) : IRandomService
    {
        private readonly Queue<object> queue = new(values);

        public int Int32 => (int)queue.Dequeue();
        public long Int64 => (long)queue.Dequeue();
        public double Double => (double)queue.Dequeue();
        public Guid Guid => (Guid)queue.Dequeue();
        public string String => (string)queue.Dequeue();
        public DateTime DateTime => (DateTime)queue.Dequeue();
    }

    public static Fixture Create(params IEnumerable<object> values)
    {
        var fixture = new Fixture();
        fixture.RegisterInstance<IRandomService>(new TestRandomService(values));
        return fixture;
    }
}
