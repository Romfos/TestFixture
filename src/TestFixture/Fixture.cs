using TestFixture.Factories;
using TestFixture.GenericFactories;

namespace TestFixture;

public sealed class Fixture
{
    private Dictionary<Type, object>? instances;
    private Dictionary<Type, Func<Fixture, object>>? functionalFactories;
    private Dictionary<Type, IFactory>? factories;
    private List<IGenericFactory>? genericFactories;

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

    public void RegisterFactory<T>(Func<Fixture, T> factory)
    {
        RegisterInstance(typeof(T), factory);
    }

    public void RegisterFactory<T>(Func<T> factory) where T : notnull
    {
        RegisterFactory(typeof(T), x => factory());
    }

    public void RegisterFactory(Type type, Func<Fixture, object> factory)
    {
        if (functionalFactories == null)
        {
            functionalFactories = new()
            {
                [type] = factory
            };
        }
        else
        {
            functionalFactories[type] = factory;
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

    public void RegisterGenericFactory(IGenericFactory genericFactory)
    {
        if (genericFactories == null)
        {
            genericFactories = [genericFactory];
        }
        else
        {
            genericFactories.Add(genericFactory);
        }
    }

    public T Create<T>()
    {
        return (T)Create(typeof(T));
    }

    public IEnumerable<T> Create<T>(int count)
    {
        return Enumerable.Range(0, count).Select(x => Create<T>());
    }

    public object Create(Type type)
    {
        if (instances != null && instances.TryGetValue(type, out var value))
        {
            return value;
        }

        if (functionalFactories != null && functionalFactories.TryGetValue(type, out var functionalFactory))
        {
            return functionalFactory(this);
        }

        if (factories != null && factories.TryGetValue(type, out var factory))
        {
            return factory.Create(this);
        }

        if (genericFactories != null)
        {
            foreach (var genericFactory in genericFactories)
            {
                if (genericFactory.Resolve(type) is IFactory typeFactory)
                {
                    RegisterFactory(type, typeFactory);
                    return typeFactory.Create(this);
                }
            }
        }

        if (SharedFixtureState.instances.TryGetValue(type, out value))
        {
            return value;
        }

        factory = SharedFixtureState.factories.GetOrAdd(type, type =>
        {
            foreach (var genericFactory in SharedFixtureState.genericFactories)
            {
                if (genericFactory.Resolve(type) is IFactory factory)
                {
                    return factory;
                }
            }

            return new DefaultClassFactory(type);
        });

        return factory.Create(this);
    }
}
