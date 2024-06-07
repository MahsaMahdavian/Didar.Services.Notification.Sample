using Didar.Services.Notification.Application.Interfaces;
using Didar.Services.Notification.Application.Publisher.Model;
using Didar.Services.Notification.Application.Services;
using Didar.Services.Notification.Domain.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Didar.Services.Notification.Application.EventHandlers;

public class SendSmsToUserCreatedEventHandler(IServiceProvider serviceProvider,
    ILogger<SendSmsToUserCreatedEventHandler> logger) : IConsumer<UserRegistredEvent>

{
    public async Task Consume(ConsumeContext<UserRegistredEvent> context)
    {
        logger.LogWarning("SendSmsToUserCreatedEventHandler invoked");
        var sendMessageService = serviceProvider.GetRequiredKeyedService<ISendMessageService>("Sms");
        await sendMessageService.SendAsync(context.Message.Email, context.Message.message);
    }
}
