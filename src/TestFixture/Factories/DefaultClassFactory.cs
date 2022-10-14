using System;
using System.Linq;
using System.Reflection;

namespace TestFixture.Factories;

internal sealed class DefaultClassFactory : IFactory
{
    private readonly ConstructorInfo constructorInfo;
    private readonly PropertyInfo[] properties;
    private readonly FieldInfo[] fields;

    public DefaultClassFactory(Type type)
    {
        constructorInfo = type.GetConstructors()[0];
        properties = type.GetProperties().Where(x => x.CanWrite).ToArray();
        fields = type.GetFields().Where(x => x.IsPublic).ToArray();
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
        foreach (var property in properties)
        {
            property.SetValue(target, fixture.Create(property.PropertyType!));
        }
    }

    private void ResolveFields(Fixture fixture, object target)
    {
        foreach (var field in fields)
        {
            field.SetValue(target, fixture.Create(field.FieldType!));
        }
    }
}
