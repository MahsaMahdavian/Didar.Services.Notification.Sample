﻿using Didar.Services.Notification.Application.EventHandlers;
using Didar.Services.Notification.Application.Features.Notification.Sms;
using Didar.Services.Notification.Application.Features.Notification.Sms.Provider;
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
        services.AddScoped<ISmsProvider, OneOfSmsProvider>();
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
            x.SetKebabCaseEndpointNameFormatter();
            x.AddConsumer<SendSmsToUserCreatedEventHandler>();
            //x.AddConsumers(typeof(AssemblyMarker).Assembly);
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri(configuration["Masstransit:RabbitMqEndpoint"]!), hst =>
                {
                    hst.Username("guest");
                    hst.Password("newpassword");
                });

                cfg.UseInMemoryOutbox(context);
                cfg.ConfigureEndpoints(context);
            });
        });
        return services;
    }
}
