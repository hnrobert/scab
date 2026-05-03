using MessagePack;

namespace Scab.ServerD.Shared.Svn.Types;

[MessagePackObject]
public readonly record struct SvnInfoResponse(
    [property: Key(0)] string  Url,
    [property: Key(1)] long    Revision,
    [property: Key(2)] string? Author = null,
    [property: Key(3)] long    Date = 0,
    [property: Key(4)] long    Size = 0,
    [property: Key(5)] string  Kind = ""
);
