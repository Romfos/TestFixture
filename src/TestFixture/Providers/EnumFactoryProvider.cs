using TestFixture.Factories;

namespace TestFixture.Providers;

internal sealed class EnumFactoryProvider : IFactoryProvider
{
    public IFactory? Resolve(Type type)
    {
        if (!type.IsEnum)
        {
            return null;
        }

        var factoryType = typeof(EnumFactory<>).MakeGenericType(type);
        return Activator.CreateInstance(factoryType) as IFactory;
    }
}
