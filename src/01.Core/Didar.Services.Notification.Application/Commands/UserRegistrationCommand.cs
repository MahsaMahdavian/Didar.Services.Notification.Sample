using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Application.Commands;

public record  UserRegistrationCommand(string Name, string PhoneNumber, string EmailAddress)
    :IRequest;
