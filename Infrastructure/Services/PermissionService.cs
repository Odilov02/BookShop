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
    public class PermissionService:Repository<Permission>,IPermissionService
    {
        IApplicatonDbcontext _db;
        public PermissionService(IApplicatonDbcontext db):base(db)
        {
            _db = db;
        }
    }
}
