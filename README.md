# Description
Small experemental fixture library for unit tests

# Example
```csharp

var fixture = new Fixture();
var array = fixture.Create<string[]>();

```

# Supported platforms

- .NET 6+
- .NET Framework 4.6.2+
- .NET Standard 2.0 (for some older runtimes)

# Nuget
https://www.nuget.org/packages/TestFixture

# Supported Types
- Base: `byte, sbyte, short, ushort, int, uint, long, ulong, float, double, decimal, char, string, bool`
- Enums
- System: `Guid, Uri, Nullable<>`
- Dates: `TimeSpan, DateTime, DateTimeOffset, TimeOnly (.NET 6+ only), DateOnly (.NET 6+ only)`
- 1d arrays
- Collections: `List<>, Dictionary<,>, IEnumerable<>, ICollection<>, IList<>`
- Immutable collections: `ImmutableArray<>, ImmutableList<>, ImmutableDictionary<,>`
- Composition of supported types in class, record, struct (inject method: first constructor, public set properties, public fields)
