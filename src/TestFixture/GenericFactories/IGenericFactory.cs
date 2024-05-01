using TestFixture.Factories;

namespace TestFixture.GenericFactories;

public interface IGenericFactory
{
    IFactory? Resolve(Type type);
}
