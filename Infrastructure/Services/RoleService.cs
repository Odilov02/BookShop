using Application.Abstraction;
using Domain.Entities.IdentityEntities;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Interfaces.ServiceInterfaces
{
    public class RoleService : Repository<Role>, IRoleService
    {
        IApplicatonDbcontext _db;
        public RoleService(IApplicatonDbcontext db) : base(db)
        {
            _db = db;
        }
    }
}
