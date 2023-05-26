using Application.Abstraction;
using Domain.Entities.IdentityEntities;
using Infrastructure.Services;

namespace Application.Interfaces.ServiceInterfaces
{
    public class PermissionService : Repository<Permission>, IPermissionService
    {
        IApplicatonDbcontext _db;
        public PermissionService(IApplicatonDbcontext db) : base(db)
        {
            _db = db;
        }
    }
}
