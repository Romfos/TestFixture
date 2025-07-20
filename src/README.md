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

- BCL types:

| Category     | Types                                                                                          |
|--------------|------------------------------------------------------------------------------------------------|
| Primitives   | byte, sbyte, short, ushort, int, uint, long, ulong, float, double, decimal, char, string, bool |
| System types | Enum, Guid, Uri, Nullable<>                                                                    |
| Date & Time  | TimeSpan, DateTime, DateTimeOffset, TimeOnly (.NET 6+), DateOnly (.NET 6+)                     |

- Collections:

| Generic               | Immutable                        | Concurrent              | Frozen (.NET 8+)    |
|-----------------------|-----------------------------------|-------------------------|---------------------|
| Array[]               | ImmutableArray<>                  | ConcurrentDictionary<,> | FrozenDictionary<,> |
| List<>                | ImmutableList<>                   | ConcurrentBag<>         | FrozenSet<>         |
| Dictionary<,>         | ImmutableDictionary<,>            | ConcurrentQueue<>       |                     |
| Queue<>               | ImmutableQueue<>                  | ConcurrentStack<>       |                     |
| Stack<>               | IImmutableList<>                  |                         |                     |
| HashSet<>             | IImmutableQueue<>                 |                         |                     |
| SortedSet<>           | IImmutableDictionary<,>           |                         |                     |
| LinkedList<>          | ImmutableHashSet<>                |                         |                     |
| SortedDictionary<,>   | ImmutableSortedSet<>              |                         |                     |
| SortedList<,>         | ImmutableSortedDictionary<,>      |                         |                     |
|                       | ImmutableStack<>                  |                         |                     |
| IEnumerable<>         |                                   |                         |                     |
| ICollection<>         |                                   |                         |                     |
| IQueryable<>          |                                   |                         |                     |
| IList<>               |                                   |                         |                     |
| IDictionary<,>        |                                   |                         |                     |
| IAsyncEnumerable<>    |                                   |                         |                     |
| IReadOnlyList<>       |                                   |                         |                     |
| IReadOnlyCollection<> |                                   |                         |                     |


- Composition of supported types in class, record, struct (inject method: first constructor, public set properties, public fields)
