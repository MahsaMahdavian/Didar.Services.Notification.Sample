using Didar.Services.Notification.Application.Features.Notification.Sms;
using Didar.Services.Notification.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Application.Services;

public class SmsService(ISmsProvider smsProvider,
    IDbContext dbContext): ISendMessageService
{
    private readonly IDbContext _dbContext= dbContext;

    public string Name => "Sms";

    //we can have a List Of Provider If one of them was not available ,switch to another one
    public Task SendAsync(string Address, string message)
    {
        //Call provider
        var result=smsProvider.SendAsnc(Address, message);
        //Add info to DB
    
        //return trackerId to user
        return Task.CompletedTask;
    }
}
