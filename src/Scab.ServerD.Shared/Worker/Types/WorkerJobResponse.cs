using MessagePack;

namespace Scab.ServerD.Shared.Worker.Types;

[MessagePackObject]
public readonly record struct WorkerJobResponse(
    [property: Key(0)] string  JobId,
    [property: Key(1)] int     Status,
    [property: Key(2)] string? OutputPath = null,
    [property: Key(3)] string? ErrorMessage = null
);
