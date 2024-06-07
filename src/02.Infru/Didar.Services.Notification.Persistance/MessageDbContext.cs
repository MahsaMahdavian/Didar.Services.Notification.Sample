using Didar.Services.Notification.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Didar.Services.Notification.Persistance;

public class MessageDbContext : DbContext
{
    public MessageDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }
    public DbSet<Sms> Sms => Set<Sms>();
}
