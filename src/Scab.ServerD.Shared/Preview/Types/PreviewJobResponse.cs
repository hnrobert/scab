using MessagePack;

namespace Scab.ServerD.Shared.Preview.Types;

[MessagePackObject]
public readonly record struct PreviewJobResponse(
    [property: Key(0)] string             JobId,
    [property: Key(1)] EPreviewJobStatus  Status,
    [property: Key(2)] string?            CacheKey = null,
    [property: Key(3)] string?            ErrorMessage = null
);
