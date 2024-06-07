using Didar.Services.Notification.Application.Interfaces;
using Didar.Services.Notification.Application.Publisher.Model;
using Didar.Services.Notification.Application.Services;
using Didar.Services.Notification.Domain.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Didar.Services.Notification.Application.EventHandlers;

public class SendEmailToUserEventHandler(IServiceProvider serviceProvider,
    ILogger<SendEmailToUserEventHandler> logger) : INotificationHandler<DomainEventWrapper<UserRegistredEvent>>

{
    public async Task Handle(DomainEventWrapper<UserRegistredEvent> notification, CancellationToken cancellationToken)
    {
        logger.LogWarning("SendEmailToUserEventHandler invoked");
        var sendMessageService=serviceProvider.GetRequiredKeyedService<ISendMessageService>("Email");
        //if here EmailService Was Down the messages wont be deleted in DB
        //becuase of OutBox Pattern
        //so in my job I get them until my service starts to work 
        await sendMessageService.SendAsync(notification.DomainEvent.Email, notification.DomainEvent.message);
    }
}
