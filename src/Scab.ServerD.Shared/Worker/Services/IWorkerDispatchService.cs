using Scab.ServerD.Shared.Worker.Types;
using MagicOnion;

namespace Scab.ServerD.Shared.Worker.Services;

public interface IWorkerDispatchService : IService<IWorkerDispatchService>
{
    UnaryResult<WorkerJobResponse> SubmitJobAsync(WorkerJobRequest request);
    UnaryResult<WorkerJobResponse> GetJobStatusAsync(WorkerJobRequest request);
}
