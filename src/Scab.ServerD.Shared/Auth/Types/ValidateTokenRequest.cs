using MessagePack;

namespace Scab.ServerD.Shared.Auth.Types;

[MessagePackObject]
public readonly record struct ValidateTokenRequest(
    [property: Key(0)] string Token
);
