using Didar.Services.Notification.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Persistance.Configuration;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(200);
        builder.HasOne(c => c.UserWallet).WithOne(c => c.User)
            .HasForeignKey<UserWalletEntity>(c => c.UserId);

        builder.Navigation(c => c.UserWallet).AutoInclude();

        builder.ToTable("users", "usr");
    }
}
