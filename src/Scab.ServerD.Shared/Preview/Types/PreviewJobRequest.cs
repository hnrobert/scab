using MessagePack;

namespace Scab.ServerD.Shared.Preview.Types;

[MessagePackObject]
public readonly record struct PreviewJobRequest(
    [property: Key(0)] string JobId,
    [property: Key(1)] string RepoUrl,
    [property: Key(2)] string Path,
    [property: Key(3)] long   Revision
);
