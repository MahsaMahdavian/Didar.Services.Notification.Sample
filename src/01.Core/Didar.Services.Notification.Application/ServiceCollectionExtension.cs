using Didar.Services.Notification.Application.Interfaces;
using Didar.Services.Notification.Application.Publisher;
using Didar.Services.Notification.Application.Services;
using Didar.Services.Notification.Domain;
using MassTransit;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Didar.Services.Notification.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ApplicationServices(this IServiceCollection services,
         IConfiguration configuration)
    {
        services.AddKeyedScoped<ISendMessageService, EmailService>("Email");
        services.AddKeyedScoped<ISendMessageService,SmsService>("Sms");

        services.AddHostedService<EventPublisherWorker>();
        var assembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(assembly);
            configuration.AutoRegisterRequestProcessors = true;
            configuration.NotificationPublisher = new TaskWhenAllPublisher();
        });

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(configuration["EventBusSettings:HostAddress"]);
            });

            x.AddConsumers(typeof(AssemblyMarker).Assembly);
        });
        return services;
    }
}
