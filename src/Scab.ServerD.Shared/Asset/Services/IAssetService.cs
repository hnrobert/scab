using Scab.ServerD.Shared.Asset.Types;
using MagicOnion;

namespace Scab.ServerD.Shared.Asset.Services;

public interface IAssetService : IService<IAssetService>
{
    UnaryResult<AssetSearchResponse> SearchAsync(AssetSearchRequest request);
    UnaryResult<TagAssetResponse> TagAssetAsync(TagAssetRequest request);
}
