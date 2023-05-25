using Application.Abstraction;
using Domain.Entities;
using Domain.Entities.IdentityEntities;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
