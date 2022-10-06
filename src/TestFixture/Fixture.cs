using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TestFixture.Factories;

namespace TestFixture;

public sealed class Fixture
{
    private readonly ImmutableArray<IFactory> factories;

    public Fixture()
    {
        factories = CreateDefaultFactories().ToImmutableArray();
    }

    public Fixture(IEnumerable<IFactory> customFactories)
    {
        factories = CreateDefaultFactories().Concat(customFactories).ToImmutableArray();
    }

    private IEnumerable<IFactory> CreateDefaultFactories()
    {
        var factoryType = typeof(IFactory);

        return GetType().Assembly.GetTypes()
            .Where(x => x.IsClass && !x.IsAbstract && !x.IsGenericType)
            .Where(x => factoryType.IsAssignableFrom(x))
            .Select(x => Activator.CreateInstance(x))
            .Cast<IFactory>();
    }

    public T Create<T>()
    {
        return (T)Create(typeof(T));
    }

    public IEnumerable<T> Create<T>(int number)
    {
        return Enumerable.Range(0, number).Select(x => Create<T>());
    }

    internal object Create(Type type)
    {
        foreach (var factory in factories)
        {
            if (factory.TryCreate(this, type, out var value))
            {
                return value!;
            }
        }

        throw new Exception($"Unable to create fixture for {type.FullName}");
    }
}
