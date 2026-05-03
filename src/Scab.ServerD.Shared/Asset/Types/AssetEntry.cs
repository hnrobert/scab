using System.Collections.Immutable;
using MessagePack;

namespace Scab.ServerD.Shared.Asset.Types;

[MessagePackObject]
public readonly record struct AssetEntry(
    [property: Key(0)] string                    Id,
    [property: Key(1)] string                    RepoUrl,
    [property: Key(2)] string                    Path,
    [property: Key(3)] string                    FileName,
    [property: Key(4)] long                      Revision,
    [property: Key(5)] long                      FileSize,
    [property: Key(6)] ImmutableArray<string>    Tags,
    [property: Key(7)] string?                   Description = null,
    [property: Key(8)] string?                   PreviewCacheKey = null,
    [property: Key(9)] long                      LastModified = 0
);
