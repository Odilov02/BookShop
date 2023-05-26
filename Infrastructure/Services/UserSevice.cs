using Application.Abstraction;
using Domain.Entities;
using Infrastructure.Services;

namespace Application.Interfaces.ServiceInterfaces
{
    public class UserSevice : Repository<User>, IUserService
    {
        IApplicatonDbcontext _db;
        public UserSevice(IApplicatonDbcontext db) : base(db)
        {
            _db = db;
        }
    }
}
