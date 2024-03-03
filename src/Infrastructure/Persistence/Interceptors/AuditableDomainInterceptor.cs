using Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PdfGenerator.Domain.Shared;

namespace Infrastructure.Persistence.Interceptors;

public class AuditableDomainInterceptor: SaveChangesInterceptor
{
    private readonly string user = "DefaultUser";
    private readonly DateTime _dateTime = DateTime.UtcNow;

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateAuditProperties(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        UpdateAuditProperties(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    
    private void UpdateAuditProperties(DbContext? eventDataContext)
    {
        if (eventDataContext is null) return;
        
        foreach (var entry in eventDataContext.ChangeTracker.Entries<IAuditableDomain>())
        {
            if (entry.State is not (EntityState.Added or EntityState.Modified) &&
                !entry.HasChangedOwnedEntities()) continue;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = user;
                entry.Entity.CreatedAt = _dateTime;
            }
            entry.Entity.LastModifierBy = user;
            entry.Entity.LastModifierDate = _dateTime;
        }
    }
}