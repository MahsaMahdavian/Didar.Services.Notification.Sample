using Didar.Services.Notification.Application.Commands;
using Didar.Services.Notification.Application.Interfaces;
using Didar.Services.Notification.Application.Services;
using Didar.Services.Notification.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Application.Features.Handler;

public class UserRegistrationCommandHandler(EmailService emailService, IDbContext dbContext)
    : IRequestHandler<UserRegistrationCommand>
{
    public async Task Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
    {
        var user = UserEntity.Create(request.Name, request.PhoneNumber, request.EmailAddress);
        //save To Db
        await dbContext.SaveAsync(cancellationToken);
        //await emailService.SendEmailAsync(user.EmailAddress, "You registred Succefully,Welcome!");
        
    }
}
