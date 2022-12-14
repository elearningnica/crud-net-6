using crud_net_6.Data.Interfaces;
using crud_net_6.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace crud_net_6.Data.Repositories
{
    public class GenericRepository<T> : IStudent<T> where T : class
    {
        protected CrudNet6Context _context;

        public GenericRepository(CrudNet6Context context)
        {
            this._context = context;
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public T add(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public virtual async Task<bool> existsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().AnyAsync(predicate);
        }

        public void update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
