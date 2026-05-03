using MessagePack;
using Microsoft.AspNetCore.Http;

namespace Scab.Shared;

[MessagePackObject]
public readonly record struct AuthContext(
    [property: Key(0)] string? Token = null,
    [property: Key(1)] string? UserAgent = null,
    [property: Key(2)] string? Origin = null,
    [property: Key(3)] string? UserId = null
)
{
    public static AuthContext FromHttpContext(HttpContext? httpContext)
    {
        if (httpContext == null) return new AuthContext();

        var token     = httpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
        var userAgent = httpContext.Request.Headers.UserAgent.ToString();
        var origin    = httpContext.Request.Headers.Origin.ToString();

        return new AuthContext(
            string.IsNullOrWhiteSpace(token) ? null : token,
            string.IsNullOrWhiteSpace(userAgent) ? null : userAgent,
            string.IsNullOrWhiteSpace(origin) ? null : origin
        );
    }

    [IgnoreMember]
    public bool IsAuthenticated => !string.IsNullOrWhiteSpace(Token);
}
