using System;
using TestFixture.Factories;

namespace TestFixture.Providers;

public sealed class TypeFactoryProvider : IFactoryProvider
{
    private readonly Type targetType;
    private readonly Type factoryType;

    public TypeFactoryProvider(Type targetType, Type factoryType)
    {
        this.targetType = targetType;
        this.factoryType = factoryType;
    }

    public IFactory? Resolve(Type type)
    {
        if (targetType != type)
        {
            return null;
        }

        return Activator.CreateInstance(factoryType) as IFactory;
    }
}
