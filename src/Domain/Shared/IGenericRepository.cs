using System.Linq.Expressions;

namespace PdfGenerator.Domain.Shared;

public interface IGenericRepository<T, TU> where T: BaseDomain
{
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);
}