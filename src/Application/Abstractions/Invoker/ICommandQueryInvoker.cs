using Application.Common;

using Domain.Common;

namespace Application.Abstractions.Invoker;
public interface ICommandQueryInvoker
{
    Task<Result<InvokingUser>> GetInvokingUser(CancellationToken cancellationToken = default);
}
