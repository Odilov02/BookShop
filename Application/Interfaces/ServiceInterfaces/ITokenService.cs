using Domain.Entities;
using System.Security.Claims;

namespace Application.Interfaces.ServiceInterfaces;

public interface ITokenService
{
    string CreateAccesToken(User user);
    Task<string> CreateRefreshAccesToken(User user);
    Task<bool> IsActiveAsync(string token);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}

