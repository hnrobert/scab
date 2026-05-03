using Scab.ServerD.Shared.Preview.Types;
using MagicOnion;

namespace Scab.ServerD.Shared.Preview.Services;

public interface IPreviewService : IService<IPreviewService>
{
    UnaryResult<PreviewResponse> GetPreviewAsync(PreviewRequest request);
    UnaryResult<PreviewJobResponse> RequestPreviewAsync(PreviewJobRequest request);
    UnaryResult<PreviewJobResponse> GetJobStatusAsync(PreviewJobRequest request);
}
