using Application.Abstraction;
using Application.Interfaces;
using System.Linq.Expressions;

namespace Infrastructure.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IApplicatonDbcontext _db;

        public Repository(IApplicatonDbcontext db)
        {
            _db = db;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
          await  _db.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<T>> Get(Expression<Func<T, bool>> expression)
        {
            ICollection<T> entities = _db.Set<T>().Where(expression).ToList();
            await _db.SaveChangesAsync();
            return entities;
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
