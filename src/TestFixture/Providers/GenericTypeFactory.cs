using System;
using TestFixture.Factories;

namespace TestFixture.Providers;

public sealed class GenericTypeFactoryProvider : IFactoryProvider
{
    private readonly Type baseType;
    private readonly Type factoryBaseType;
    private readonly int baseTypeGenericArgumentCount;

    public GenericTypeFactoryProvider(Type baseType, Type factoryBaseType)
    {
        this.baseType = baseType;
        this.factoryBaseType = factoryBaseType;

        baseTypeGenericArgumentCount = baseType.GetGenericArguments().Length;
    }

    public IFactory? Resolve(Type type)
    {
        if (type.IsGenericType)
        {
            var arguments = type.GetGenericArguments();
            if (arguments.Length == baseTypeGenericArgumentCount && type == baseType.MakeGenericType(arguments))
            {
                var factoryType = factoryBaseType.MakeGenericType(arguments);
                return Activator.CreateInstance(factoryType) as IFactory;
            }
        }

        return null;
    }
}
