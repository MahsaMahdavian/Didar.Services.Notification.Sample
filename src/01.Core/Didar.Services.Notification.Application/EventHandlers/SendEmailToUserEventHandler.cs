using Didar.Services.Notification.Application.Publisher.Model;
using Didar.Services.Notification.Application.Services;
using Didar.Services.Notification.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Didar.Services.Notification.Application.EventHandlers;

public class SendEmailToUserEventHandler(EmailService emailService,
    ILogger<SendEmailToUserEventHandler> logger) : INotificationHandler<DomainEventWrapper<UserRegistredEvent>>

{
    public async Task Handle(DomainEventWrapper<UserRegistredEvent> notification, CancellationToken cancellationToken)
    {
        logger.LogWarning("SendEmailToUserEventHandler invoked");

        //if here EmailService Was Down the messages wont be deleted in DB
        //becuase of OutBox Pattern
        //so in my job I get them until my service starts to work 
        await emailService.SendEmailAsync(notification.DomainEvent.Email, notification.DomainEvent.message);
    }
}
