using System.Collections.Immutable;
using MessagePack;

namespace Scab.ServerD.Shared.Worker.Types;

[MessagePackObject]
public readonly record struct WorkerJobRequest(
    [property: Key(0)] string                       JobId,
    [property: Key(1)] EWorkerJobType               JobType,
    [property: Key(2)] string                       FilePath,
    [property: Key(3)] ImmutableDictionary<string, string>? Parameters = null
);
