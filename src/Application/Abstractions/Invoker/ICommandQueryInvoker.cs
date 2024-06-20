using Application.Common;

using Domain.Common;

namespace Application.Abstractions.Invoker;
public interface ICommandQueryInvoker
{
    Task<Result<InvokingUser>> GetInvokingUserAsync(CancellationToken cancellationToken = default);
}
