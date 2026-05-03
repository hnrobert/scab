using Grpc.Net.ClientFactory;
using MagicOnion;
using MagicOnion.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Scab.Shared;

public static class MagicOnionExtensions
{
    public static IHttpClientBuilder AddMagicOnionClient<T>(this IServiceCollection services,
        Action<GrpcClientFactoryOptions>? configureClient = null)
        where T : class, IService<T>
    {
        return services.AddGrpcClient<T>((sp, options) =>
        {
            options.Creator = MagicOnionClient.Create<T>;
            configureClient?.Invoke(options);
        });
    }
}
