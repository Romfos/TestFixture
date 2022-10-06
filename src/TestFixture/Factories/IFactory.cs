using System;

namespace TestFixture.Factories;

public interface IFactory
{
    bool TryCreate(Fixture fixture, Type type, out object? value);
}
