using System;

namespace TestFixture.Services;

public sealed class RandomService : IRandomService
{
    private readonly Random random = new();

    public int Int32 => random.Next();

    public Guid Guid => Guid.NewGuid();

    public string String => $"string_{Guid}";
}
