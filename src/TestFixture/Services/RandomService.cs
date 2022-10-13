using System;

namespace TestFixture.Services;

public sealed class RandomService : IRandomService
{
    private readonly Random random = new();

    public int Int32 => random.Next();

    public long Int64 => random.Next();

    public double Double => random.NextDouble();

    public Guid Guid => Guid.NewGuid();

    public string String => $"string_{Guid}";

    public DateTime DateTime => DateTime.UtcNow;

    public TimeSpan TimeSpan => DateTime.UtcNow.TimeOfDay;
}
