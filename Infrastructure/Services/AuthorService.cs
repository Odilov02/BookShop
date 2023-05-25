using Application.Abstraction;
using Domain.Entities;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterfaces
{
    public class AuthorService:Repository<Author>, IAuthorService
    {
        private readonly IApplicatonDbcontext _db;

        public AuthorService(IApplicatonDbcontext db):base(db)
        { 
            _db = db;
        }
       

    }
}
