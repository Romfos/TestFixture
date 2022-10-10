using System;
using TestFixture.Factories;

namespace TestFixture.Providers;

public sealed class GenericTypeFactory : IFactoryProvider
{
    private readonly Type baseType;
    private readonly Type factoryBaseType;

    public GenericTypeFactory(Type baseType, Type factoryBaseType)
    {
        this.baseType = baseType;
        this.factoryBaseType = factoryBaseType;
    }

    public IFactory? Resolve(Type type)
    {
        if (type.IsGenericType)
        {
            var arguments = type.GetGenericArguments();
            if (arguments.Length == 1 && type == baseType.MakeGenericType(arguments[0]))
            {
                var factoryType = factoryBaseType.MakeGenericType(arguments[0]);
                return Activator.CreateInstance(factoryType) as IFactory;
            }
        }

        return null;
    }
}
