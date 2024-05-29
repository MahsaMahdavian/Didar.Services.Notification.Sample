using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Domain.Entities.Common;

public abstract class BaseEntity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public long Id { get; private set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }

    public void RaiseEvent(IDomainEvent @event) => _domainEvents.Add(@event);

    public void ClearEvents() => _domainEvents.Clear();

    public IReadOnlyList<IDomainEvent> GetDomainEvents => _domainEvents.AsReadOnly();
}
