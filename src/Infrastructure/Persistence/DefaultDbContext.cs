using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PdfGenerator.Domain.Shared;

namespace Infrastructure.Persistence;

public class  DefaultDbContext: DbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;

    private void UpdateAuditProperties()
    {
        foreach (var entry in ChangeTracker.Entries<IAuditableDomain>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = "DefaultUser";
                    entry.Entity.CreatedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifierBy = "DefaultUser";
                    entry.Entity.LastModifierDate = DateTime.Now;
                    break;

                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options, IPublisher publisher)
    :base(options)
    {
        _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker.Entries<BaseDomain>()
            .Select(m => m.Entity)
            .Where(m => m.GetDomainEvents().Any())
            .SelectMany(m => m.GetDomainEvents());

        UpdateAuditProperties();

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}