using System;

namespace TestFixture.Services;

public interface IRandomService
{
    int Int32 { get; }

    long Int64 { get; }

    double Double { get; }

    Guid Guid { get; }

    string String { get; }

    DateTime DateTime { get; }

    TimeSpan TimeSpan { get; }
}
