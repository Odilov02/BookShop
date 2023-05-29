using Application.Abstraction;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities.Tokens;

namespace Infrastructure.Services
{
    public class RefreshTokenService : Repository<RefreshToken>, IRefreshTokenService
    {
        IApplicatonDbcontext _db;
        public RefreshTokenService(IApplicatonDbcontext db) : base(db)
        {
            _db = db;
        }
    }
}
