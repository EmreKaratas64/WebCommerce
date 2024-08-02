using System.Linq.Expressions;

namespace WebCommerce.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(int id);

        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
