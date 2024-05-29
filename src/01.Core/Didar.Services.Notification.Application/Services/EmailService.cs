using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Application.Services;

public class EmailService(ILogger<EmailService> logger)
{
   public Task SendEmailAsync(string email,string message)
    {
        logger.LogWarning("Sending Email to {email} with message {message}",email,message);
        return Task.CompletedTask;
    }
}
