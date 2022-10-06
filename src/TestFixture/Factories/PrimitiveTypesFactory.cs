using System;

namespace TestFixture.Factories;

internal sealed class PrimitiveTypesFactory : IFactory
{
    private readonly Random random = new();

    public bool TryCreate(Fixture fixture, Type type, out object? value)
    {
        if (type == typeof(int))
        {
            value = random.Next();
            return true;
        }
        if (type == typeof(Guid))
        {
            value = Guid.NewGuid();
            return true;
        }
        if (type == typeof(string))
        {
            value = $"string_{Guid.NewGuid()}";
            return true;
        }

        value = default;
        return false;
    }
}
