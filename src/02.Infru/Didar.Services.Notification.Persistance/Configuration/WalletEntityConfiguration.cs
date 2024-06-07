using Didar.Services.Notification.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Persistance.Configuration;

public class WalletEntityConfiguration : IEntityTypeConfiguration<UserWalletEntity>
{
    public void Configure(EntityTypeBuilder<UserWalletEntity> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.WalletChargeAmount)
            .HasPrecision(9, 3);

        builder.Navigation(c => c.User).AutoInclude();

        builder.ToTable("UserWallets", "usr");
    }
}