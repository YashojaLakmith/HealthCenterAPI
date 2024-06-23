using System.Security.Claims;

using Application.Abstractions.Invoker;
using Application.Common;

using Domain.Common;
using Domain.Common.Errors;
using Domain.Enum;

namespace Web.HttpContextUser;

public sealed class HttpActionInvoker : ICommandQueryInvoker
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpActionInvoker(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Task<Result<InvokingUser>> GetInvokingUserAsync(CancellationToken cancellationToken = default)
    {
        Result<InvokingUser> result;
        if(_httpContextAccessor.HttpContext is null)
        {
            result = Result<InvokingUser>.Failure(InvokerErrors.InvokerNotFound);
            return Task.FromResult(result);
        }

        var claims = _httpContextAccessor.HttpContext.User.Claims;
        var userIdClaim = claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.NameIdentifier));
        var roleClaim = claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Role));

        if(userIdClaim is null || roleClaim is null)
        {
            result = Result<InvokingUser>.Failure(InvokerErrors.InvokerNotFound);
            return Task.FromResult(result);
        }

        var role = (Role) Enum.Parse(typeof(Role), roleClaim.Value);

        result = Result<InvokingUser>.Success(new InvokingUser(new Guid(userIdClaim.Value), role));
        return Task.FromResult(result);
    }
}
