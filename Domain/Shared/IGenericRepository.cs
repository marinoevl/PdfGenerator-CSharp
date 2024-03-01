using System.Linq.Expressions;

namespace PdfGenerator.Domain.Shared;

public interface IGenericRepository<T, U>
{
    IUnitOfWork UnitOfWork { get; }
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<T[]> AddRangeAsync(T[] entity, CancellationToken cancellationToken = default);
    Task<T> UpdateAsync(T[] entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> GetByIdAsync(U id, CancellationToken cancellationToken = default, params string[] includes);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params string[] includes);
    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default, params string[] includes);
}