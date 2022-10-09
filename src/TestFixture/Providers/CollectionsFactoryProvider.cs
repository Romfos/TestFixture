using System;
using System.Collections.Generic;
using TestFixture.Providers;

namespace TestFixture.Factories;

internal sealed class CollectionsFactoryProvider : IFactoryProvider
{
    public IFactory? Resolve(Type type)
    {  
        if (type.IsArray)
        {
            var elementType = type.GetElementType()!;
            var factoryType = typeof(ArrayFactory<>).MakeGenericType(elementType);
            return (IFactory) Activator.CreateInstance(factoryType)!;
        }

        if(type.IsGenericType)
        {
            var arguments = type.GetGenericArguments();
            
            if (arguments.Length == 1 && type == typeof(List<>).MakeGenericType(arguments[0]))
            {
                var factoryType = typeof(ListFactory<>).MakeGenericType(arguments[0]);
                return (IFactory) Activator.CreateInstance(factoryType)!;
            }
    }

        return null;
    }
}
