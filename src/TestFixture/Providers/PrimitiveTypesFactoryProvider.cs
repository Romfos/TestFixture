using System;
using TestFixture.Providers;

namespace TestFixture.Factories;

internal sealed class PrimitiveTypesFactoryProvider : IFactoryProvider
{
    private readonly Int32Factory int32Factory = new();
    private readonly GuidFactory guidFactory = new();
    private readonly StringFactory stringFactory = new();

    public IFactory? Resolve(Type type)
    {  
        if (type == typeof(int))
        {
            return int32Factory;
        }   
        if (type == typeof(Guid))
        {
            return guidFactory;
        }
        if (type == typeof(string))
        {
            return stringFactory;
        }
        return null;
    }
}
