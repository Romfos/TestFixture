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
        var arguments = ResolveParameters(fixture);
        var target = constructorInfo.Invoke(arguments);
        ResolveProperties(fixture, target);
        ResolveFields(fixture, target);
        return target;
    }

    private object[] ResolveParameters(Fixture fixture)
    {
        return constructorInfo.GetParameters()
            .Select(x => fixture.Create(x.ParameterType))
            .ToArray();
    }

    private void ResolveProperties(Fixture fixture, object target)
    {
        foreach (var property in type.GetProperties().Where(x => x.CanWrite))
        {
            property.SetValue(target, fixture.Create(property.PropertyType!));
        }
    }

    private void ResolveFields(Fixture fixture, object target)
    {
        foreach (var field in type.GetFields().Where(x => x.IsPublic))
        {
            field.SetValue(target, fixture.Create(field.FieldType!));
        }
    }
}
