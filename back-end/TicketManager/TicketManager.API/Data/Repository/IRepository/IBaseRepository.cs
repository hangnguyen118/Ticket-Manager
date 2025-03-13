using System.Linq.Expressions;

namespace TicketManager.API.Data.Repository.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, CancellationToken cancellationToken = new CancellationToken());
        Task<T?> GetAsync(Expression<Func<T, bool>>? filter, string? includeProperties = null, CancellationToken cancellationToken = new CancellationToken());
        Task AddAsync(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        void Update(T entity);
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = new CancellationToken());
    }
}
