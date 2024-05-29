using Didar.Services.Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Domain.Entities;

public class Outbox(Guid id, IDomainEvent domainEvent)
{
    public Guid Id { get; set; } = id;
    public IDomainEvent DomainEvent { get; set; } = domainEvent;
}