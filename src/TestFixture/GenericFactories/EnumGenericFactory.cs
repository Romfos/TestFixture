using TestFixture.Factories;

namespace TestFixture.GenericFactories;

internal sealed class EnumGenericFactory : IGenericFactory
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
