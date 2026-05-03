using System.Collections.Immutable;
using MessagePack;

namespace Scab.ServerD.Shared.Svn.Types;

[MessagePackObject]
public readonly record struct SvnListResponse(
    [property: Key(0)] ImmutableArray<SvnListEntry> Entries
);
