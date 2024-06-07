using Didar.Services.Notification.Domain.Entities;
using Didar.Services.Notification.Domain.Entities.Common;
using Didar.Services.Notification.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Persistance;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }


    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<OrderEntity> Orders => Set<OrderEntity>();
    public DbSet<ProductEntity> Products => Set<ProductEntity>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OutboxEntityConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}

