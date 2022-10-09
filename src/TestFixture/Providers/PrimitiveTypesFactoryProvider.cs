using System;
using TestFixture.Factories.Primitives;
using TestFixture.Providers;

namespace TestFixture.Factories;

internal sealed class PrimitiveTypesFactoryProvider : IFactoryProvider
{
    public IFactory? Resolve(Type type)
    {
        if (type == typeof(int))
        {
            return new Int32Factory();
        }
        if (type == typeof(Guid))
        {
            return new GuidFactory();
        }
        if (type == typeof(string))
        {
            return new StringFactory();
        }
        return null;
    }
}
