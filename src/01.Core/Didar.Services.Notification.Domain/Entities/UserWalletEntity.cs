using Didar.Services.Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Domain.Entities;

public class UserWalletEntity:BaseEntity
{
    public long UserId { get; set; }
    public decimal WalletChargeAmount { get; set; }
    public UserEntity User { get; set; }
}
