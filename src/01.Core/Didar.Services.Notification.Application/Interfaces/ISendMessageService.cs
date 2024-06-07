using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Application.Interfaces
{
    public interface ISendMessageService
    {
        public string Name { get; }
        Task SendAsync(string address, string message);
    }
}
