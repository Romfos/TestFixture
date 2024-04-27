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
- Collections:

| Generic       | Interfaces            | Immutable              | Concurrent              | Frozen              |
|---------------|-----------------------|------------------------|-------------------------|---------------------|
| 1d arrays     | IEnumerable<>         | ImmutableArray<>       | ConcurrentDictionary<,> | FrozenDictionary<,> |
| List<>        | ICollection<>         | ImmutableList<>        |                         |                     |
| Dictionary<,> | IList<>               | ImmutableDictionary<,> |                         |                     |
| Queue<>       | IAsyncEnumerable<>    | ImmutableQueue<>       |                         |                     |
|               | IReadOnlyList<>       |                        |                         |                     |
|               | IReadOnlyDictionary<> |                        |                         |                     |

- Composition of supported types in class, record, struct (inject method: first constructor, public set properties, public fields)
