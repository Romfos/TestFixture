using TestFixture.Factories;

namespace TestFixture.Providers;

public sealed class GenericFactoryProvider(
    Type baseType,
    Type factoryBaseType) : IFactoryProvider
{
    private readonly int baseTypeGenericArgumentCount = baseType.GetGenericArguments().Length;

    public IFactory? Resolve(Type type)
    {
        if (!type.IsGenericType)
        {
            return null;
        }

        var arguments = type.GetGenericArguments();
        try
        {
            if (arguments.Length != baseTypeGenericArgumentCount || type != baseType.MakeGenericType(arguments))
            {
                return null;
            }
        }
        catch (ArgumentException)
        {
            return null;
        }

        var factoryType = factoryBaseType.MakeGenericType(arguments);
        return Activator.CreateInstance(factoryType) as IFactory;
    }
}
