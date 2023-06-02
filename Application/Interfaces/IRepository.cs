using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid Id);
        Task<T> AddAsync(T entity);
        Task<ICollection<T>> AddRangeAsync(ICollection<T> entities);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);

    }
}
