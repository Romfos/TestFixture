using System;
using TestFixture.Factories;

namespace TestFixture.Providers;

internal sealed class EnumFactoryProvider : IFactoryProvider
{
    public IFactory? Resolve(Type type)
    {
        if (type.IsEnum)
        {
            var factoryType = typeof(EnumFactory<>).MakeGenericType(type);
            return Activator.CreateInstance(factoryType) as IFactory;
        }

        return null;
    }
}