using Didar.Services.Notification.Application.Interfaces;
using Didar.Services.Notification.Domain.Entities;
using Didar.Services.Notification.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Didar.Services.Notification.Persistance;

public sealed class UnitOfWork(ApplicationDbContext dbContext) : IDbContext
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    //TODO: Set repository

    public DbSet<Outbox> Outboxes => _dbContext.Set<Outbox>();
    public Task SaveAsync(CancellationToken cancellationToken)
    {
        AddOutboxMessages();
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void AddOutboxMessages()
    {
        var messages = _dbContext.ChangeTracker.Entries<BaseEntity>()
            .Select(c => c.Entity)
            .SelectMany(c =>
            {
                var domainEvents = new List<IDomainEvent>(c.GetDomainEvents);

                c.ClearEvents();

                return domainEvents;
            }).ToList();

        foreach (var message in messages)
        {
            this.Outboxes.Add(new Outbox(Guid.NewGuid(), message));
        }
    }
}
