using Didar.Services.Notification.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Persistance.Configuration;

public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasOne(c => c.User).WithMany(c => c.UserOrders)
            .HasForeignKey(c => c.UserId);
        builder.HasOne(c => c.Product)
            .WithMany(c => c.RelatedOrders)
            .HasForeignKey(c => c.ProductId);

        builder.Property(c => c.OrderState)
            .HasConversion<EnumToStringConverter<OrderEntity.OrderStates>>().HasMaxLength(20);

        builder.Navigation(c => c.User).AutoInclude();
        builder.Navigation(c => c.Product).AutoInclude();

        builder.ToTable("Orders", "ord");
    }
}
