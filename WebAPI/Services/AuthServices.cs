using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using WebAPI.Abstractions.Services;
using WebAPI.Abstractions.Session;
using WebAPI.DataTransferObjects.Login;
using WebAPI.EF;

namespace WebAPI.Services;

public class AuthServices : IAuthServices
{
    private readonly ApplicationDbContext _context;
    private readonly ISessionManager _session;

    public AuthServices(ApplicationDbContext context, ISessionManager session)
    {
        _context = context;
        _session = session;
    }

    public async Task<string?> HandlePatientLoginAsync(LoginInformation loginInformation)
    {
        using var transaction = await BeginTransactionAsync();
        var cred = await _context.Credentials
            .FirstOrDefaultAsync(c => c.Employee.EmployeeId.Equals(loginInformation.UserId));

        if(cred is not null)
        {            
            cred.LastLogin = DateTime.Now;
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        return cred?.ToString();
    }

    public Task<string?> HandleEmployeeLoginAsync(LoginInformation loginInformation)
    {
        throw new NotImplementedException();
    }

    public Task HandleLogoutAsync(string token)
    {
        return _session.RevokeTokenAsync(token);
    }

    private Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return _context.Database.BeginTransactionAsync();
    }
}

public static class AuthServiceExtensions
{
    public static void AddAuthSevices(this IServiceCollection services)
    {
        services.AddScoped<IAuthServices, AuthServices>();
    }
}
