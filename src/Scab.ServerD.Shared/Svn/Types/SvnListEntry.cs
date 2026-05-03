using MessagePack;

namespace Scab.ServerD.Shared.Svn.Types;

[MessagePackObject]
public readonly record struct SvnListEntry(
    [property: Key(0)] string  Name,
    [property: Key(1)] string  Path,
    [property: Key(2)] string  Kind,       // "file" or "dir"
    [property: Key(3)] long    Size,
    [property: Key(4)] long    Revision,
    [property: Key(5)] string? Author = null,
    [property: Key(6)] long    Date = 0
);
