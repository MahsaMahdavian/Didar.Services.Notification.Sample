using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Application.Features.Notification.Sms.Provider;

public class OneOfSmsProvider : ISmsProvider
{

    public Task<string> SendAsnc(string phoneNumber, string message)
    {
        throw new NotImplementedException();
    }
    public Task<bool> InquiryAsnc(string smsId)
    {
        throw new NotImplementedException();
    }

}
