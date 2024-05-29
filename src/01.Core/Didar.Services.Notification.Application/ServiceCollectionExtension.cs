using Didar.Services.Notification.Application.Publisher;
using Didar.Services.Notification.Application.Services;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Didar.Services.Notification.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ApplicationServices(this IServiceCollection services,
         IConfiguration configuration)
    {
        services.AddSingleton<EmailService>();
        services.AddSingleton<SmsService>();
        services.AddHostedService<EventPublisherWorker>();
        var assembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(assembly);
            configuration.AutoRegisterRequestProcessors = true;
            configuration.NotificationPublisher = new TaskWhenAllPublisher();
        });
     
        return services;
    }
}
