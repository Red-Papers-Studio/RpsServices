using ModifiableEntities;

namespace Auth.Domain.Base;

public abstract class DomainEntity<TId> : BaseModifiableEntity<TId>
{
    private List<DomainEvent> _events;
    public IReadOnlyList<DomainEvent> Events => _events.AsReadOnly();

    protected void AddEvent(DomainEvent domainEvent)
    {
        _events.Add(domainEvent);
    }

    protected void RemoveEvent(DomainEvent domainEvent)
    {
        _events.Remove(domainEvent);
    }
}