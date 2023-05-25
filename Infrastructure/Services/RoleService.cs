using Application.Abstraction;
using Domain.Entities.IdentityEntities;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterfaces
{
    public class RoleService:Repository<Role>, IRoleService
    {
        IApplicatonDbcontext _db;
        public RoleService(IApplicatonDbcontext db):base(db)
        {
            _db = db;
        }
    }
}
