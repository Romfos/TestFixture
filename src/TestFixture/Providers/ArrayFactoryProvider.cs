using System;
using TestFixture.Factories;
using TestFixture.Factories.Collections;

namespace TestFixture.Providers;

internal sealed class ArrayFactoryProvider : IFactoryProvider
{
    public IFactory? Resolve(Type type)
    {
        if (!type.IsArray)
        {
            return null;
        }

        var argument = type.GetElementType()!;
        var factoryType = typeof(ArrayFactory<>).MakeGenericType(argument);
        return Activator.CreateInstance(factoryType) as IFactory;
    }
}
