---
name: project-architecture
description: Detailed architecture of the TestFixture project (factory resolution, SharedFixtureState, test seams). Use when implementing, refactoring, or debugging TestFixture internals, adding supported types, or working in src/TestFixture.
---

# TestFixture — Project Architecture

## Layout

```
src/
├─ TestFixture/                  # library (NuGet package)
│   ├─ Fixture.cs                # public API entry point (sealed class Fixture)
│   ├─ SharedFixtureState.cs     # static registry: built-in IFactory + IGenericFactory instances
│   ├─ Factories/                # per-type IFactory implementations
│   │   ├─ IFactory.cs           #   { object Create(Fixture fixture); }
│   │   ├─ DefaultClassFactory.cs#   reflection-based fallback for user types
│   │   ├─ Primitives/           #   byte, int, string, bool, ...
│   │   ├─ System/               #   Guid, Uri, DateTime, TimeOnly, DateOnly, TimeSpan
│   │   ├─ Collections/         #   List<>, Dictionary<,>, Queue, Stack, ...
│   │   │   ├─ Immutable/       #   ImmutableList<>, ImmutableDictionary<,>, ...
│   │   │   ├─ Concurrent/      #   ConcurrentDictionary<,>, ConcurrentQueue<>, ...
│   │   │   └─ Frozen/          #   FrozenDictionary<,>, FrozenSet<> (.NET 8+)
│   │   └─ ...
│   ├─ GenericFactories/         # open-generic IFactory resolution
│   │   ├─ IGenericFactory.cs    #   { IFactory? Resolve(Type type); }
│   │   ├─ GenericFactory.cs     #   maps generic open type -> closed IFactory via Activator
│   │   └─ ArrayGenericFactory.cs
│   └─ Services/                 # IRandomService abstraction (+ default RandomService)
└─ TestFixture.Tests/           # MSTest test project (one test file per supported type family)
    └─ Services/                # TestFixtureFactory: registers a deterministic test IRandomService
```

## Core design

- **`Fixture`** (public API):
  - `Create<T>()` / `Create<T>(count)` / `Create(Type)` — main entry points
  - `RegisterInstance<T>(value)` — pin an exact value for a type (e.g. a custom `IRandomService`)
  - `RegisterFactory<...>` — override how a type is built (functional `Func<Fixture, T>`, or `IFactory`)
  - `RegisterGenericFactory(IGenericFactory)` — plug in open-generic resolution
- **Resolution order in `Create`** (important, don't reorder):
  1. per-instance registrations (`instances` — pinned values)
  2. functional factories (`functionalFactories`)
  3. `IFactory` registrations (`factories`)
  4. per-instance `IGenericFactory` registrations
  5. **shared** built-in registrations (`SharedFixtureState`: instances → factories → genericFactories)
  6. fallback: `DefaultClassFactory` (reflection composition) — cached in `SharedFixtureState.factories`
- **`SharedFixtureState`** holds the default built-in factories (all primitives, `Guid`, `DateTime`, collections, immutable/concurrent/frozen collections, `EnumGenericFactory`, `Nullable<>`, etc.) so state is shared across `Fixture` instances.
- **`DefaultClassFactory`** composes user types: calls the **first constructor**, then fills **public settable properties**, then **public fields** — recursively via `fixture.Create(...)`.
- **`IRandomService`** is the only source of randomness; everything else is deterministic given it. Tests inject a fake one via `RegisterInstance<IRandomService>` (see `src/TestFixture.Tests/Services/TestFixtureFactory.cs`).

## Adding a supported type

1. Create `Factories/.../<X>Factory.cs` implementing `IFactory` (use `IRandomService` via `fixture.Create(...)` for nested/recursive composition — never `new Random()`).
2. Register it in `SharedFixtureState.factories` (for open generics: add a `GenericFactory`/`IGenericFactory` entry to `genericFactories`).
3. Add tests in `src/TestFixture.Tests/` (matching the per-family test files: `PrimitiveTests.cs`, `CollectionsTests.cs`, `EnumTests.cs`, ...).
