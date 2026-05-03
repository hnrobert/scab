using System.Collections.Immutable;
using MessagePack;

namespace Scab.ServerD.Shared.Asset.Types;

[MessagePackObject]
public readonly record struct AssetSearchResponse(
    [property: Key(0)] ImmutableArray<AssetEntry> Results,
    [property: Key(1)] int                        TotalCount
);
