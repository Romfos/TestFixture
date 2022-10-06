using System;
using System.Collections.Generic;
using System.Linq;
using TestFixture.Factories;

namespace TestFixture;

public sealed class Fixture
{
    private readonly IFactory[] factories;

    public Fixture()
    {
        var factoryType = typeof(IFactory);
        factories = GetType().Assembly.GetTypes()
            .Where(x => x.IsClass && !x.IsAbstract && !x.IsGenericType)
            .Where(x => factoryType.IsAssignableFrom(x))
            .Select(x => Activator.CreateInstance(x))
            .Cast<IFactory>()
            .ToArray();
    }

    public Fixture(IEnumerable<IFactory> factories) : this()
    {
        this.factories = this.factories.Concat(factories).ToArray();
    }

    public T? Create<T>()
    {
        if (TryCreate(typeof(T), out var value))
        {
            return (T)value!;
        }
        return default;
    }

    internal bool TryCreate(Type type, out object? value)
    {
        foreach (var factory in factories)
        {
            if (factory.TryCreate(this, type, out value))
            {
                return true;
            }
        }

        value = default;
        return false;
    }
}
