using System;
using TestFixture.Factories;

namespace TestFixture.Providers;

public sealed class GenericFactoryProvider : IFactoryProvider
{
    private readonly Type baseType;
    private readonly Type factoryBaseType;
    private readonly int baseTypeGenericArgumentCount;

    public GenericFactoryProvider(Type baseType, Type factoryBaseType)
    {
        this.baseType = baseType;
        this.factoryBaseType = factoryBaseType;

        baseTypeGenericArgumentCount = baseType.GetGenericArguments().Length;
    }

    public IFactory? Resolve(Type type)
    {
        if (!type.IsGenericType)
        {
            return null;
        }

        var arguments = type.GetGenericArguments();
        try
        {
            if (arguments.Length != baseTypeGenericArgumentCount || type != baseType.MakeGenericType(arguments))
            {
                return null;
            }
        }
        catch (ArgumentException)
        {
            return null;
        }

        var factoryType = factoryBaseType.MakeGenericType(arguments);
        return Activator.CreateInstance(factoryType) as IFactory;
    }
}
