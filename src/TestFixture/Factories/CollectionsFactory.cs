using System;
using System.Collections;
using System.Collections.Generic;

namespace TestFixture.Factories;

internal sealed class CollectionsFactory : IFactory
{
    public bool TryCreate(Fixture fixture, Type type, out object? value)
    {
        if (type.IsArray)
        {
            value = CreateArray(type, fixture);
            return true;
        }

        if (type.IsGenericType
            && type.GenericTypeArguments.Length == 1
            && type.IsAssignableFrom(typeof(List<>).MakeGenericType(type.GenericTypeArguments[0])))
        {
            value = CreateList(type, fixture);
            return true;
        }

        value = default;
        return false;
    }

    private object CreateArray(Type type, Fixture fixture)
    {
        var elementType = type.GetElementType()!;
        var array = Array.CreateInstance(elementType, 3);
        for (var i = 0; i < 3; i++)
        {
            array.SetValue(fixture.Create(elementType), i);
        }
        return array;
    }

    private object CreateList(Type type, Fixture fixture)
    {
        var elementType = type.GenericTypeArguments[0];
        var listType = typeof(List<>).MakeGenericType(type.GenericTypeArguments[0]);
        var list = (IList)Activator.CreateInstance(listType)!;
        for (var i = 0; i < 3; i++)
        {
            list.Add(fixture.Create(elementType));
        }
        return list;
    }
}