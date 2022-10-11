using System;
using TestFixture.Factories;
using TestFixture.Providers;
using TestFixture.Services;

namespace TestFixture.Tests.Services;

internal sealed class MockFactoryProvider : IFactoryProvider
{
    private readonly MockRandomServiceFactory mockRandomServiceFactory;

    public MockFactoryProvider(MockRandomServiceFactory mockRandomServiceFactory)
    {
        this.mockRandomServiceFactory = mockRandomServiceFactory;
    }

    public IFactory? Resolve(Type type)
    {
        if (type == typeof(IRandomService))
        {
            return mockRandomServiceFactory;
        }

        return null;
    }
}
