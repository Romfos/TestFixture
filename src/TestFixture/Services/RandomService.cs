using System;

namespace TestFixture.Services;

public sealed class RandomService : IRandomService
{
    private readonly Random random = new();

    public int Int32 => random.Next();

#if NET6_0
    public long Int64 => random.NextInt64();
#else
    public long Int64 => random.Next();
#endif

    public double Double => random.NextDouble();

    public Guid Guid => Guid.NewGuid();

    public string String => $"string_{Guid}";

    public DateTime DateTime => DateTime.UtcNow;

    public TimeSpan TimeSpan => DateTime.UtcNow.TimeOfDay;
}
