using Didar.Services.Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Domain.Entities;

public class Sms: BaseEntity
{
    public string TraceId { get; set; }
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
    public string RefrenceId { get; set; }
    public SmsStatusTrack Status { get; set; }

    public static Sms Create(string traceId,
        string phoneNumber,
        string message,
        string refrenceId,
        string status) => new Sms
        {
            TraceId = traceId,
            PhoneNumber = phoneNumber,
            Message = message,
            CreateDate = DateTime.Now,
            RefrenceId = refrenceId,
            Status = SmsStatusTrack.Sent
        };
}

public enum SmsStatusTrack
{
    Sent,
    Inquiry,
    Failed,
    Delivered
}

