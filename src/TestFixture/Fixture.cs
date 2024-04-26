using TestFixture.Factories;
using TestFixture.Providers;

namespace TestFixture;

public sealed class Fixture
{
    private Dictionary<Type, object>? instances;
    private Dictionary<Type, IFactory>? factories;
    private List<IFactoryProvider>? providers;

    public void RegisterInstance<T>(T value)
        where T : notnull
    {
        RegisterInstance(typeof(T), value);
    }

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

    public void RegisterFactory<T>(IFactory factory)
    {
        RegisterFactory(typeof(T), factory);
    }

    public void RegisterFactory(Type type, IFactory factory)
    {
        if (factories == null)
        {
            factories = new()
            {
                [type] = factory
            };
        }
        else
        {
            factories[type] = factory;
        }
    }

    public void RegisterProvider(IFactoryProvider factoryProvider)
    {
        if (providers == null)
        {
            providers = [factoryProvider];
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

    public object Create(Type type)
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
