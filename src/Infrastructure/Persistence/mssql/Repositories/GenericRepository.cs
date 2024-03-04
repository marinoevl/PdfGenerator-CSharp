using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PdfGenerator.Domain.Shared;

namespace Infrastructure.Persistence.mssql.Repositories;

public class GenericRepository<T, TU> :IGenericRepository<T, TU> where T: BaseDomain
{
    private readonly DefaultDbContext _context;

    public GenericRepository(DefaultDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default) =>
        await _context.Set<T>().AddAsync(entity, cancellationToken);

    public void Update(T entity) =>
        _context.Set<T>().Update(entity);

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) => await _context.Set<T>().SingleOrDefaultAsync(predicate, cancellationToken);

    public IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null)
    {
        return predicate is null ? _context.Set<T>().AsQueryable() : _context.Set<T>().Where(predicate).AsQueryable();
    }
}