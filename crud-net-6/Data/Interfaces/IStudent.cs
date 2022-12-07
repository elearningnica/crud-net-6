using System.Linq.Expressions;

namespace crud_net_6.Data.Interfaces
{
    public interface IStudent<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> existsAsync(Expression<Func<T, bool>> predicate);
        Task<bool> SaveChangesAsync();
        T add(T entity);
    }
}
