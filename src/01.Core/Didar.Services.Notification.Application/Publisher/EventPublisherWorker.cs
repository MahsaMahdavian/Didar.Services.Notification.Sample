using Didar.Services.Notification.Application.Interfaces;
using Didar.Services.Notification.Application.Publisher.Model;
using Didar.Services.Notification.Domain.Entities;
using Didar.Services.Notification.Domain.Entities.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Application.Publisher;

public class EventPublisherWorker(IServiceScopeFactory scopeFactory, ILogger<EventPublisherWorker> logger)
    : BackgroundService
{
    readonly IServiceScopeFactory _scopeFactory = scopeFactory;
    readonly ILogger<EventPublisherWorker> _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var serviceProvider = _scopeFactory.CreateScope();

                var dbContext = serviceProvider.ServiceProvider.GetRequiredService<IDbContext>();
                var mediateRPublisher = serviceProvider.ServiceProvider.GetRequiredService<IPublisher>();

                var outBoxEvents = await dbContext.Outboxes.ToListAsync(cancellationToken: stoppingToken);

                var eventsToRemove = new List<Outbox>();

                foreach (var outBoxEvent in outBoxEvents)
                {
                    try
                    {
                        var eventWrapperModel =
                           Activator.CreateInstance(
                               typeof(DomainEventWrapper<>).MakeGenericType(outBoxEvent.DomainEvent.GetType()),
                               new object[] { outBoxEvent.DomainEvent });

                        if (eventWrapperModel is not null)
                            await mediateRPublisher.Publish(eventWrapperModel, stoppingToken);

                        eventsToRemove.Add(outBoxEvent);

                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, "There was an error publishing event ");
                    }
                }

                if (eventsToRemove.Any())
                {
                    // delete from Db
                    dbContext.Outboxes.RemoveRange(eventsToRemove);

                    await dbContext.SaveAsync(stoppingToken);
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            await Task.Delay(2000, stoppingToken);
        }
    }
}
