namespace PdfGenerator.Domain.Shared;

public abstract class BaseDomain
{
    private readonly List<DomainEvent> _domainEvents = new();
    public ICollection<DomainEvent> GetDomainEvents() => _domainEvents;

    protected void AddDomainEvents(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    
    protected void RemoveDomainEvents(DomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }
    
    protected void ClearDomainEvents(DomainEvent domainEvent)
    {
        _domainEvents.Clear();
    }
}