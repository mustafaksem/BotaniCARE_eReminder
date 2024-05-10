using eReminderServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eReminderServer.Infrastructure.Configurations
{
    internal sealed class GardenerConfiguration : IEntityTypeConfiguration<Gardener>
    {
        public void Configure(EntityTypeBuilder<Gardener> builder)
        {
            builder.Property(p=> p.FirstName).HasColumnType("varchar(50)");
            builder.Property(p=> p.LastName).HasColumnType("varchar(50)");
            builder.Property(p=> p.Mail).HasColumnType("varchar(50)");
        }        
    }
}

