
using Microsoft.AspNetCore.Builder;
namespace Didar.Services.Notification.Framework.Extention;

public static class ServiceInstallerExtensions
{
    public static WebApplicationBuilder InstallService<TInstaller>(this WebApplicationBuilder builder)
      where TInstaller : class, IServiceInstaller, new()
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        var installer = new TInstaller();
        installer.Install(builder);
        return builder;
    }
}
