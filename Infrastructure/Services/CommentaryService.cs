using Application.Abstraction;
using Domain.Entities;
using Infrastructure.Services;

namespace Application.Interfaces.ServiceInterfaces
{
    public class CommentarySerivce : Repository<Commentary>, ICommentaryService
    {
        private readonly IApplicatonDbcontext _db;

        public CommentarySerivce(IApplicatonDbcontext db) : base(db)
        {
            _db = db;
        }
    }
}
