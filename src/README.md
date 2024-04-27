# Description

Small fixture library for unit tests

# Example

```csharp

[TestMethod]
public void ExampleTest()
{
    // arrange
    var underTest = new MyService();
    
    var fixture = new Fixture();
    var testData = fixture.Create<string[]>();

    // act
    var actual = underTest.Add(testData);

    // assert
    Assert.AreEqual(3, actual);
}

```

# Supported Types

- Base: `byte, sbyte, short, ushort, int, uint, long, ulong, float, double, decimal, char, string, bool`
- Enums
- System: `Guid, Uri, Nullable<>`
- Dates: `TimeSpan, DateTime, DateTimeOffset, TimeOnly (.NET 6+ only), DateOnly (.NET 6+ only)`
- 1d arrays
- Collections: `List<>, Dictionary<,>, IEnumerable<>, ICollection<>, IList<>, IAsyncEnumerable<>, Queue<>, Stack<>`
- Concurrent collections: `ConcurrentDictionary<,>`
- Immutable collections: `ImmutableArray<>, ImmutableList<>, ImmutableDictionary<,>, ImmutableQueue<>`
- Frozen collections (.NET 8+ only): `FrozenDictionary<,>`
- Composition of supported types in class, record, struct (inject method: first constructor, public set properties, public fields)