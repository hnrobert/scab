using System.Collections.Immutable;
using MessagePack;

namespace Scab.ServerD.Shared.Asset.Types;

[MessagePackObject]
public readonly record struct AssetSearchRequest(
    [property: Key(0)] string?                      Query = null,
    [property: Key(1)] ImmutableArray<string>        Tags = default,
    [property: Key(2)] string?                       FileType = null,
    [property: Key(3)] int                           Limit = 50,
    [property: Key(4)] int                           Offset = 0
);
