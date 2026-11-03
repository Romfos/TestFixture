# AGENTS.md

## Project description

**TestFixture** is a small, dependency-free .NET NuGet library that generates random test data ("fixtures") for unit tests.
It creates realistic values for BCL primitives, enums, `Guid`/`Uri`/`DateTime`-family types, a wide range of
generic collections (mutable, concurrent, immutable and frozen), and arbitrary user classes/records/structs
by reflection-based composition.

Typical usage:

```csharp
var fixture = new Fixture();
var testData = fixture.Create<string[]>();
var person  = fixture.Create<Person>(); // fills ctor + public set props + public fields
```

The project is published to NuGet as [`TestFixture`](https://www.nuget.org/packages/TestFixture).

## Tech stack

- **Language:** C# (latest, implicit usings / file-scoped namespaces style per existing code)
- **Target frameworks:** `net10.0` and `net11.0` (multi-targeting; `net11.0` enables the `runtime-async` feature)
- **Test project:** MSTest 4.4.0, run via **Microsoft.Testing.Platform** (MTP; `global.json` configures `test.runner = Microsoft.Testing.Platform`)
- **Build/CI:** .NET SDK 10/11, GitHub Actions (`verify.yml` runs on push, `release.yml` is manual `workflow_dispatch` to publish the NuGet package with symbols via `dotnet pack -p:CI=true`)
- **Packageing:** NuGet (`dotnet pack`, snupkg symbol package in CI), MIT licensed
- **No third-party runtime dependencies** in the library itself — it relies purely on BCL (`System.Collections.Frozen`, `System.Collections.Immutable`, `System.Collections.Concurrent`)

## Project architecture

See the `project-architecture` skill (`.agents/skills/project-architecture/SKILL.md`) for the detailed architecture: layout, `Fixture` resolution order, `SharedFixtureState`, `DefaultClassFactory` composition, and the `IRandomService` determinism seam.

## Coding rules

See the `coding-rules` skill (`.agents/skills/coding-rules/SKILL.md`) for the project's coding rules: naming and style conventions, determinism (`IRandomService`) rules, multi-targeting constraints, test conventions, and CI expectations.

## Useful reference

- Build: `dotnet build src/TestFixture.slnx`
- Test: `dotnet test` (uses MTP per `global.json`)
- Pack (local, as CI does): `dotnet pack ./src/TestFixture/TestFixture.csproj -p:Version=<version> -p:CI=true`
- Full type-support matrix lives in `README.md` — update it when adding types.
- CI workflows: `.github/workflows/verify.yml` (on push: build+test) and a release workflow (manual, NuGet publish with OIDC `id-token: write`).
