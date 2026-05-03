using MessagePack;

namespace Scab.ServerD.Shared.Auth.Types;

[MessagePackObject]
public readonly record struct LoginRequest(
    [property: Key(0)] string Username,
    [property: Key(1)] string Password
);
