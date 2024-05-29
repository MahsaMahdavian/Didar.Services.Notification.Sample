
using Microsoft.AspNetCore.Builder;
namespace Didar.Services.Notification.Framework.Extention;

public interface IServiceInstaller
{
    public void Install(WebApplicationBuilder builder);
}
