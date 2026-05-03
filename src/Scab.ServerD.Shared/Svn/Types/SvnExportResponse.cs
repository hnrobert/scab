using MessagePack;

namespace Scab.ServerD.Shared.Svn.Types;

[MessagePackObject]
public readonly record struct SvnExportResponse(
    [property: Key(0)] string LocalFilePath,
    [property: Key(1)] long   FileSize
);
