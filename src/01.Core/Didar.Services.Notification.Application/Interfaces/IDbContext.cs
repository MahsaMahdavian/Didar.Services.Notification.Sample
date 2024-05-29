using Didar.Services.Notification.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Application.Interfaces;

public interface IDbContext
{
     DbSet<Outbox> Outboxes { get; }
    Task SaveAsync(CancellationToken cancellationToken);
    void AddOutboxMessages();


}
