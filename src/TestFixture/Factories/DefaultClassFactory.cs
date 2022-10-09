using System;
using System.Linq;
using System.Reflection;

namespace TestFixture.Factories;

internal sealed class DefaultClassFactory : IFactory
{
    private readonly Type type;
    private readonly ConstructorInfo constructorInfo;

    public DefaultClassFactory(Type type)
    {
        this.type = type;
        constructorInfo = type.GetConstructors()[0];
    }

    public object Create(Fixture fixture)
    {
        var parameters = constructorInfo.GetParameters()
            .Select(x => fixture.Create(x.ParameterType))
            .ToArray();

        var target = constructorInfo.Invoke(parameters);

        foreach (var property in type.GetProperties().Where(x => x.CanWrite))
        {
            property.SetValue(target, fixture.Create(property.PropertyType!));
        }

        foreach (var field in type.GetFields().Where(x => x.IsPublic))
        {
            field.SetValue(target, fixture.Create(field.FieldType!));
        }

        return target;
    }
}

