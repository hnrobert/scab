using MessagePack;

namespace Scab.ServerD.Shared.Preview.Types;

[MessagePackObject]
public readonly record struct PreviewResponse(
    [property: Key(0)] string CacheKey,
    [property: Key(1)] byte[] ImageData,
    [property: Key(2)] int    Width,
    [property: Key(3)] int    Height,
    [property: Key(4)] string ContentType
);
