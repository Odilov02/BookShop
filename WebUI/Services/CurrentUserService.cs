using Application.Interfaces.ServiceInterfaces;
using System.Security.Claims;

namespace WebUI.Services;

public class CurrentUserService : ICurrentUserService
{
    public string GetUserId()
    {
        var claims = ClaimsPrincipal.Current!.Identities.First().Claims.ToList();
        var UserId =  claims?.FirstOrDefault(x => x.Type.Equals("UserId", StringComparison.OrdinalIgnoreCase))?.Value;
        return UserId!;
    }
}

