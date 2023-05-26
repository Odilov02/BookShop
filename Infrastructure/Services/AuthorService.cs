using Application.Abstraction;
using Domain.Entities;
using Infrastructure.Services;

namespace Application.Interfaces.ServiceInterfaces
{
    public class AuthorService : Repository<Author>, IAuthorService
    {
        private readonly IApplicatonDbcontext _db;

        public AuthorService(IApplicatonDbcontext db) : base(db)
        {
            _db = db;
        }


    }
}
