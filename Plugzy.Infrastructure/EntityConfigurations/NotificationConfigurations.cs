using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations;

public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Title).HasColumnName("Title")
            .HasColumnType("varchar(100)");
        builder.Property(p => p.Description).HasColumnName("Description")
            .HasColumnType("varchar(1000)");
        builder.Property(p => p.ReadAt).HasColumnName("ReadAt");

        builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
        builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
        builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy");
        builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(p => p.DeletedBy).HasColumnName("DeletedBy");
        builder.Property(p => p.DeletedAt).HasColumnName("DeletedAt");
    }
}
