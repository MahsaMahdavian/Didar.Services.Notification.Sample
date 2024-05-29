using Didar.Services.Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Domain.Events;

public record  UserRegistredEvent(string Email,string message): IDomainEvent;
