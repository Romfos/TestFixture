using TestFixture.Services;

namespace TestFixture.Factories;

internal sealed class EnumFactory<T> : IFactory
    where T : struct, Enum
{
    public object Create(Fixture fixture)
    {
        var values = (T[])Enum.GetValues(typeof(T));
        var index = fixture.Create<IRandomService>().Int32 % values.Length;
        return values[index];
    }
}
