using Scab.ServerD.Shared.Svn.Types;
using MagicOnion;

namespace Scab.ServerD.Shared.Svn.Services;

public interface ISvnService : IService<ISvnService>
{
    UnaryResult<SvnListResponse> ListAsync(SvnListRequest request);
    UnaryResult<SvnInfoResponse> InfoAsync(SvnInfoRequest request);
    UnaryResult<SvnExportResponse> ExportAsync(SvnExportRequest request);
}
