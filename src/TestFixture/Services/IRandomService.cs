using System;

namespace TestFixture.Services;

public interface IRandomService
{
    int Int32 { get; }

    Guid Guid { get; }

    string String { get; }
}
