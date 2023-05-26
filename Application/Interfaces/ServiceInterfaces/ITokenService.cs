using Domain.Entities;
using System.Security.Claims;

namespace Application.Interfaces.ServiceInterfaces;

public interface ITokenService
{
    Task<string> CreateAccesToken(User user);
    string CreateRefreshAccesToken(User user);
    Task<bool> IsActive(string token);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}

