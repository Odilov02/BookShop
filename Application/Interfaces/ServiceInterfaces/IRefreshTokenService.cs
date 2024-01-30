using Domain.Entities.Tokens;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IRefreshTokenService : IRepository<RefreshToken>
    {
    }
}
