using Didar.Services.Notification.Application.Interfaces;
using Didar.Services.Notification.Application.Publisher.Model;
using Didar.Services.Notification.Application.Services;
using Didar.Services.Notification.Domain.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Didar.Services.Notification.Application.EventHandlers;

public class SendCreatedOrderSmsEventHandler(
    IServiceProvider serviceProvider,
    ILogger<SendCreatedOrderSmsEventHandler> logger
    )  : INotificationHandler<DomainEventWrapper<SendCreatedOrderSmsEvent>>
{
    public async Task Handle(DomainEventWrapper<SendCreatedOrderSmsEvent> notification, CancellationToken cancellationToken)
    {
        logger.LogWarning("SendCreatedOrderSmsEventHandler Invoked");
       var ServiceSendMessage= serviceProvider.GetRequiredKeyedService<ISendMessageService>("Sms");
        await ServiceSendMessage.SendAsync(notification.DomainEvent.Phoneumber,
            notification.DomainEvent.Message);
    }
}
