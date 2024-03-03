namespace PdfGenerator.Domain.Shared;

public abstract class BaseDomain(Guid id)
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public Guid Id { get; set; } = id;

    public IEnumerable<IDomainEvent> GetDomainEvents() => _domainEvents;

    protected void AddDomainEvents(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    protected void RemoveDomainEvents(IDomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public static bool operator ==(BaseDomain? baseDomain1, BaseDomain? baseDomain2)
    {
        return baseDomain1 is not null && baseDomain2 is not null && baseDomain1.Equals(baseDomain2);
    }

    public static bool operator !=(BaseDomain? baseDomain1, BaseDomain? baseDomain2) => !(baseDomain1 == baseDomain2);

    public bool Equals(BaseDomain? other)
    {
        if (other is null) return false;
        if (other.GetType() != GetType()) return false;

        return other.Id == Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj.GetType() != GetType()) return false;

        if (obj is not BaseDomain baseDomain) return false;

        return baseDomain.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}