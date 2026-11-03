---
name: coding-rules
description: Coding rules and conventions for the TestFixture project. Use when writing or reviewing C# code in src/TestFixture or src/TestFixture.Tests, adding factories, or preparing changes for CI.
---

# TestFixture — Coding Rules

- **Language/style:** plain C#, no external libraries. File-scoped namespaces. `sealed` classes for internal implementations. Public API surface is small: `Fixture`, `IFactory`, `IGenericFactory`, `IRandomService`.
- **Naming:** one type per file; factory classes named `<Type>Factory` (e.g. `Int32Factory`), generic factories named `<OpenGenericType>GenericFactory` (e.g. `ArrayGenericFactory`) or implemented as `GenericFactory` registrations in `SharedFixtureState`.
- **Adding a supported type:**
  1. Create `Factories/.../<X>Factory.cs` implementing `IFactory` (use `IRandomService` via `fixture.Create(...)` for nested/recursive composition — never `new Random()`).
  2. Register it in `SharedFixtureState.factories` (for open generics: add a `GenericFactory`/`IGenericFactory` entry to `genericFactories`).
  3. Add tests in `src/TestFixture.Tests/` (matching the per-family test files: `PrimitiveTests.cs`, `CollectionsTests.cs`, `EnumTests.cs`, ...).
- **Determinism:** never call `Random`/`Guid.NewGuid()`/`DateTime` directly in factory code — go through `IRandomService` so tests can pin values.
- **Nullability/typing:** `Create` returns `object` and casts on the generic path; keep the `notnull` constraints where present. Prefer `Dictionary`/`ConcurrentDictionary` fields over auto-properties for lazily-built state (the codebase style uses `private Dictionary<...>?` fields built on first use — follow that).
- **Multi-targeting:** any new API must work on both `net10.0` and `net11.0`. `Frozen*` collections require `.NET 8+` (fine, already used); `TimeOnly`/`DateOnly` require `.NET 6+`. `IAsyncEnumerable<>` factories rely on the `net11.0` `runtime-async` feature.
- **Tests:** MTP + MSTest. Use `TestFixtureFactory.Create(...)` with the deterministic fake `IRandomService` for value assertions; keep the `Arrange/Act/Assert` comments as in the README example.
- **Public API:** avoid breaking changes — the package is published; prefer adding over changing signatures.
- **Commits/PRs:** keep changes small; CI (`verify.yml`) builds on 10.0.x and 11.0.x runners on `windows-latest` — run `dotnet test` locally (MTP) before pushing.
