using Didar.Services.Notification.Domain.Entities.Common;
using Didar.Services.Notification.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Domain.Entities;

public class UserEntity : BaseEntity
{
    public string Name { get; private set; }
    public string PhoneNumber { get; private set; }
    public string EmailAddress { get; private set; }
    public List<OrderEntity> UserOrders { get; private set; }
    public UserWalletEntity UserWallet { get; private set; }

    public static UserEntity Create(string name, string phoneNumber, string emailAddress)
    {
        var user = new UserEntity()
        {
            Name = name,
            PhoneNumber = phoneNumber,
            EmailAddress = emailAddress,
            CreateDate = DateTime.Now,
        };

        user.RaiseEvent(new UserRegistredEvent(emailAddress, "UserRegistred"));
        return user;
    }

}
