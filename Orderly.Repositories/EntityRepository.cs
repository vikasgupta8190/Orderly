using Microsoft.EntityFrameworkCore;
using Orderly.Core.Domain.Common;
using Orderly.Core.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Repositories
{
    public class EntityRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public EntityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task InsertAsync(T entity)
        {
            await this._context.Set<T>().AddAsync(entity);
            await this._context.SaveChangesAsync();
        }

        public async Task InsertAllAsync(List<T> entity)
        {
            await this._context.Set<T>().AddRangeAsync(entity);
            await this._context.SaveChangesAsync();
        }
                                                                    
        public async Task DeleteAsync(T entity)
        {
            this._context.Set<T>().Remove(entity);
            await this._context.SaveChangesAsync();
        }
        public async Task DeleteAllAsync(List<T> entities)
        {
            this._context.Set<T>().RemoveRange(entities);
            await this._context.SaveChangesAsync();
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult<IQueryable<T>>(this._context.Set<T>().AsNoTracking());
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.FromResult<IQueryable<T>>(this._context.Set<T>()
           .Where(expression).AsNoTracking());
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this._context.Set<T>()
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this._context.Set<T>().Update(entity);
            this._context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task UpdateAllAsync(List<T> entities)
        {
            this._context.Set<T>().UpdateRange(entities);
            await this._context.SaveChangesAsync();
        }
    }
}
