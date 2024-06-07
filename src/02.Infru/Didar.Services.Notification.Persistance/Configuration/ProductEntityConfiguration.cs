using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Didar.Services.Notification.Domain.Entities;

namespace Didar.Services.Notification.Persistance.Configuration;

public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.ProductName).HasMaxLength(100);
        builder.ToTable("Products", "prd");
    }
}
