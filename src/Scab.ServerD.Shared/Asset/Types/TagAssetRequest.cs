using System.Collections.Immutable;
using MessagePack;

namespace Scab.ServerD.Shared.Asset.Types;

[MessagePackObject]
public readonly record struct TagAssetRequest(
    [property: Key(0)] string                 AssetId,
    [property: Key(1)] ImmutableArray<string> Tags
);
