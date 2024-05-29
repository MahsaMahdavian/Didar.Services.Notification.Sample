using Didar.Services.Notification.Framework.Extention;
using Didar.Services.Notification.Persistance;

namespace Didar.Services.Notification.WebApi.Installer
{
    public class InfrastructureInstaller : IServiceInstaller
    {
        public void Install(WebApplicationBuilder builder)
        {
            builder.Services.PersistanceServices(builder.Configuration);
        }
    }
}
