using Didar.Services.Notification.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Didar.Services.Notification.Persistance;

public static class ServiceCollectionExtension
{
    public static IServiceCollection PersistanceServices(this IServiceCollection services,
         IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(x =>
        {
            x.UseSqlServer(configuration.GetConnectionString("ApplicationDb"));
            x.LogTo(Console.WriteLine);
        });
        services.AddDbContext<MessageDbContext>(x =>
        {
            //x.UseSqlServer(connectionString);
            x.LogTo(Console.WriteLine);
        });
        services.AddScoped<IDbContext, UnitOfWork>();
        return services;
    }
}
