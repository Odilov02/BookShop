using Application.Abstraction;
using Domain.Entities;
using Infrastructure.Services;

namespace Application.Interfaces.ServiceInterfaces
{
    public class BookService : Repository<Book>, IBookService
    {
        private readonly IApplicatonDbcontext _db;

        public BookService(IApplicatonDbcontext db) : base(db)
        {
            _db = db;
        }
    }
}
