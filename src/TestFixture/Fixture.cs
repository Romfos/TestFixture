using System;
using System.Collections.Generic;
using System.Linq;
using TestFixture.Factories;
using TestFixture.Providers;

namespace TestFixture;

public sealed class Fixture
{
    private Dictionary<Type, object>? instances;
    private Dictionary<Type, IFactory>? factories;
    private List<IFactoryProvider>? providers;

    public void RegisterInstance(Type type, object value)
    {
        if (instances == null)
        {
            instances = new()
            {
                [type] = value
            };
        }
        else
        {
            instances[type] = value;
        }
    }

    public void RegisterFactory(Type type, IFactory value)
    {
        if (factories == null)
        {
            factories = new()
            {
                [type] = value
            };
        }
        else
        {
            factories[type] = value;
        }
    }

    public void RegisterProvider(IFactoryProvider factoryProvider)
    {
        if (providers == null)
        {
            providers = new()
            {
                factoryProvider
            };
        }
        else
        {
            providers.Add(factoryProvider);
        }
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
        if (instances != null && instances.TryGetValue(type, out var value))
        {
            return value;
        }

        if (factories != null && factories.TryGetValue(type, out var factory))
        {
            return factory.Create(this);
        }

        if (providers != null)
        {
            factory = providers.Select(provider => provider.Resolve(type)).FirstOrDefault(x => x != null);
            if (factory != null)
            {
                RegisterFactory(type, factory);
                return factory.Create(this);
            }
        }

        if (SharedFixtureState.instances.TryGetValue(type, out value))
        {
            return value;
        }

        factory = SharedFixtureState.factories.GetOrAdd(type, type =>
            SharedFixtureState.providers
                .Select(provider => provider.Resolve(type))
                .FirstOrDefault(x => x != null) ?? new DefaultClassFactory(type));

        return factory.Create(this);
    }
}
