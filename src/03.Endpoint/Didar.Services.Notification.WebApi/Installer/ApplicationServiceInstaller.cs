using Didar.Services.Notification.Application;
using Didar.Services.Notification.Framework.Extention;

namespace Didar.Services.Notification.WebApi.Installer;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(WebApplicationBuilder builder)
    {
        builder.Services.ApplicationServices(builder.Configuration);
    }
}
