using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Application.Features.Notification.Sms;

public interface ISmsProvider
{
    Task<string> SendAsnc(string phoneNumber, string message);
    Task<bool> InquiryAsnc(string smsId);
    string Name {  get; }   
}
