using Microsoft.EntityFrameworkCore;
using PdfGenerator.Domain.Shared;

namespace Infrastructure.Persistence;

public class DefaultDbContext: DbContext, IUnitOfWork
{
    private readonly IMediator _mediator;
        
    public Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
    {
        await _
    }
}