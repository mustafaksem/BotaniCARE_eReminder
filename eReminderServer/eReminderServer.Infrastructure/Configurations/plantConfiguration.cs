using eReminderServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eReminderServer.Infrastructure.Configurations
{
    internal sealed class plantConfiguration : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.Property(p => p.Name).HasColumnType("varchar(50)");
            builder.Property(p => p.Description).HasColumnType("varchar(50)");
            builder.HasIndex(x => x.Name).IsUnique();
        }

    }
}

