using TestFixture.Factories;

namespace TestFixture.Providers;

public interface IFactoryProvider
{
    IFactory? Resolve(Type type);
}
