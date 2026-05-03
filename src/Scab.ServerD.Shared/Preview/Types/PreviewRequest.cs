using MessagePack;

namespace Scab.ServerD.Shared.Preview.Types;

[MessagePackObject]
public readonly record struct PreviewRequest(
    [property: Key(0)] string            RepoUrl,
    [property: Key(1)] string            Path,
    [property: Key(2)] long              Revision,
    [property: Key(3)] EPreviewImageSize Size = EPreviewImageSize.Medium
);
