using MessagePack;

namespace Scab.ServerD.Shared.Auth.Types;

[MessagePackObject]
public readonly record struct LoginResponse(
    [property: Key(0)] string Token,
    [property: Key(1)] long   ExpiresAt
);
