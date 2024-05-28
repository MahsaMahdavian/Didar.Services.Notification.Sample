using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Application.Services;

public class SmsService
{
    public Task SendAsync(string phoneNuber,string message)
    {
        //Call provider
        //Add info to DB
        //return trackerId to user
        return Task.CompletedTask;
    }
}
