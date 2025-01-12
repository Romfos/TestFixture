# Description

Small fixture library for unit tests

[![.github/workflows/verify.yml](https://github.com/Romfos/TestFixture/actions/workflows/verify.yml/badge.svg)](https://github.com/Romfos/TestFixture/actions/workflows/verify.yml)
[![TestFixture](https://img.shields.io/nuget/v/TestFixture?label=TestFixture)](https://www.nuget.org/packages/TestFixture)

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

# Nuget

https://www.nuget.org/packages/TestFixture

# Supported Types

- BCL types:

| Category     | Types                                                                                          |
|--------------|------------------------------------------------------------------------------------------------|
| Primitives   | byte, sbyte, short, ushort, int, uint, long, ulong, float, double, decimal, char, string, bool |
| System types | Enum, Guid, Uri, Nullable<>                                                                    |
| Date & Time  | TimeSpan, DateTime, DateTimeOffset, TimeOnly (.NET 6+), DateOnly (.NET 6+)                     |

- Collections:

| Generic               | Immutable               | Concurrent              | Frozen (.NET 8+)    |
|-----------------------|-------------------------|-------------------------|---------------------|
| Array[]               | ImmutableArray<>        | ConcurrentDictionary<,> | FrozenDictionary<,> |
| List<>                | ImmutableList<>         | ConcurrentBag<>         |                     |
| Dictionary<,>         | ImmutableDictionary<,>  | ConcurrentQueue<>       |                     |
| Queue<>               | ImmutableQueue<>        | ConcurrentStack<>       |                     |
| Stack<>               | IImmutableList<>        |                         |                     |
| IEnumerable<>         | IImmutableQueue<>       |                         |                     |
| ICollection<>         | IImmutableDictionary<,> |                         |                     |
| IList<>               |                         |                         |                     |
| IDictionary<,>        |                         |                         |                     |
| IAsyncEnumerable<>    |                         |                         |                     |
| IReadOnlyList<>       |                         |                         |                     |
| IReadOnlyCollection<> |                         |                         |                     |

- Composition of supported types in class, record, struct (inject method: first constructor, public set properties, public fields)
