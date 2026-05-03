using MessagePack;

namespace Scab.ServerD.Shared.Svn.Types;

[MessagePackObject]
public readonly record struct SvnInfoRequest(
    [property: Key(0)] string RepoUrl,
    [property: Key(1)] string Path,
    [property: Key(2)] long   Revision = -1
);
