using Orderly.Core.Domain.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Repositories
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task InsertAllAsync(List<T> entity);
        Task UpdateAsync(T entity);
        Task UpdateAllAsync(List<T> entity);
        Task DeleteAsync(T entity);
        Task DeleteAllAsync(List<T> mappings);
    }
}
