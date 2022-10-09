using System;
using System.Collections.Generic;
using TestFixture.Factories.Collections;
using TestFixture.Providers;

namespace TestFixture.Factories;

internal sealed class CollectionsFactoryProvider : IFactoryProvider
{
    public IFactory? Resolve(Type type)
    {
        var factoryType = GetFactoryType(type);
        if (factoryType == null)
        {
            return null;
        }
        return (IFactory)Activator.CreateInstance(factoryType)!;
    }

    private Type? GetFactoryType(Type type)
    {
        if (type.IsArray)
        {
            return GetSingleArgumentFactoryType(type, type.GetElementType()!);
        }

        if (type.IsGenericType)
        {
            var arguments = type.GetGenericArguments();
            if (arguments.Length == 1)
            {
                return GetSingleArgumentFactoryType(type, arguments[0]);
            }
        }

        return null;
    }

    private Type? GetSingleArgumentFactoryType(Type type, Type argument)
    {
        if (type.IsArray && type.GetArrayRank() == 1)
        {
            return typeof(ArrayFactory<>).MakeGenericType(argument);
        }

        if (type == typeof(List<>).MakeGenericType(argument))
        {
            return typeof(ListFactory<>).MakeGenericType(argument);
        }

        return null;
    }
}
