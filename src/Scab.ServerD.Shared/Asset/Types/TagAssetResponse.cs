using MessagePack;

namespace Scab.ServerD.Shared.Asset.Types;

[MessagePackObject]
public readonly record struct TagAssetResponse(
    [property: Key(0)] bool Success
);
