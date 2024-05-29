using Didar.Services.Notification.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Didar.Services.Notification.Domain.Entities.Common;

namespace Didar.Services.Notification.Persistance.Configuration;

public class OutboxEntityConfiguration : IEntityTypeConfiguration<Outbox>
{
    public void Configure(EntityTypeBuilder<Outbox> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.DomainEvent)
            .HasConversion(@event => JsonConvert.SerializeObject(@event, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            }), eventModel => JsonConvert.DeserializeObject<IDomainEvent>(eventModel, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            }));
    }
}
