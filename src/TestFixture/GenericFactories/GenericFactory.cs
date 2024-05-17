using TestFixture.Factories;

namespace TestFixture.GenericFactories;

public sealed class GenericFactory(Type genericType, Type genericTypeFactoryType) : IGenericFactory
{
    public IFactory? Resolve(Type type)
    {
        if (!type.IsGenericType)
        {
            return null;
        }

        if (genericType != type.GetGenericTypeDefinition())
        {
            return null;
        }

        var arguments = type.GetGenericArguments();
        var factoryType = genericTypeFactoryType.MakeGenericType(arguments);
        return Activator.CreateInstance(factoryType) as IFactory;
    }
}
