using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PdfGenerator.Domain.Shared;

namespace Infrastructure.Persistence.Interceptors;

public sealed class DispatchDomainEventsInterceptor(IPublisher mediator) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();

        return base.SavingChanges(eventData, result);

    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await DispatchDomainEvents(eventData.Context);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private async Task DispatchDomainEvents(DbContext? eventDataContext)
    {
        if (eventDataContext == null) return;

        var entities = eventDataContext.ChangeTracker
            .Entries<BaseDomain>()
            .Where(e => e.Entity.GetDomainEvents().Any())
            .Select(e => e.Entity);

        var domainEvents = entities
            .SelectMany(e => e.GetDomainEvents())
            .ToList();

        entities.ToList().ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}