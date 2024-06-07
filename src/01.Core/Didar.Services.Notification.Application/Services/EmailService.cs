using Didar.Services.Notification.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Application.Services;

public class EmailService(ILogger<EmailService> logger): ISendMessageService
{
    public string Name => "Email";

    public Task SendAsync(string address,string message)
    {
        logger.LogWarning("Sending Email to {address} with message {message}", address,message);
        return Task.CompletedTask;
    }
}
