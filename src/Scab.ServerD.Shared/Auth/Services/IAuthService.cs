using Scab.ServerD.Shared.Auth.Types;
using Scab.Shared;
using MagicOnion;

namespace Scab.ServerD.Shared.Auth.Services;

public interface IAuthService : IService<IAuthService>
{
    UnaryResult<LoginResponse> LoginAsync(LoginRequest request);
    UnaryResult ValidateTokenAsync(ValidateTokenRequest request, AuthContext? authContext = null);
}
