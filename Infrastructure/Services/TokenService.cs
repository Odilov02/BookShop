using Application.Extentions;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities;
using Domain.Entities.IdentityEntities;
using Domain.Entities.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IRefreshTokenService _tokenService;
    public TokenService(IConfiguration configuration, IRefreshTokenService tokenService)
    {
        _configuration = configuration;
        _tokenService = tokenService;
    }
    public async Task<string> CreateAccesToken(User user)
    {

        List<Claim> claims = new List<Claim>();
        claims.Add(new Claim("UserId", user.Id.ToString()));
        claims.Add(new Claim("password", user.Password));
        ICollection<Role>? roles = user.Roles;
        List<Permission> permissions = new List<Permission>();

        foreach (Role role in roles!)
        {
            permissions.AddRange(role.permissions!);
        }
        foreach (var permission in permissions)
        {
            claims.Add(new Claim(ClaimTypes.Role, permission.PermissionName));
        }
        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:Issuer"],
            audience: _configuration["JWT:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(int.Parse(_configuration["JWT:AccesExpires"]!)),
            signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!)),
                    SecurityAlgorithms.HmacSha256)
            );
        string result = new JwtSecurityTokenHandler().WriteToken(token);
        return result;

    }

    public async Task<string> CreateRefreshAccesToken(User user)
    {
        string? tokenString = DateTime.UtcNow.ToString() + user.Password;
        tokenString = tokenString.stringHash();

        RefreshToken? token = await _tokenService.Get(user.Id);
        if (token == null)
        {
            RefreshToken refreshToken = new()
            {
                Refresh = tokenString!,
                ActiveDate = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JWT:RefreshExpires"]!)),
                UserId = user.Id
            };
            await _tokenService.AddAsync(refreshToken!);
        }
        else
        {
            token.Refresh = tokenString!;
            token.ActiveDate = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JWT:RefreshExpires"]!));
            await _tokenService.UpdateAsync(token);
        }
        return tokenString!;
    }
    public async Task<bool> IsActive(string token)
    {
        ICollection<RefreshToken> refreshTokens = await _tokenService.GetAll(x => true);
        var refreshToken = refreshTokens.FirstOrDefault(x => x.Refresh == token);
        if (refreshToken == null) return false;
        if (DateTime.UtcNow < refreshToken!.ActiveDate)
            return true;
        return false;

    }
    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {

        var Key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _configuration["JWT:Issuer"],
            ValidAudience = _configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        JwtSecurityToken? jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            return new();

        }
        return principal;
    }

}
