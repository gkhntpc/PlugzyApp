using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations;

public class SocketConfigurations : IEntityTypeConfiguration<Socket>
{
    public void Configure(EntityTypeBuilder<Socket> builder)
    {
        builder.ToTable("Socket").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Number).HasColumnName("Number")
            .HasColumnType("varchar(100)");
        builder.Property(p => p.Kw).HasColumnName("Kw")
            .HasColumnType("decimal(19,2)");
        builder.Property(p => p.CurrentType).HasColumnName("CurrentType")
            .HasColumnType("tinyint");
        builder.Property(p => p.Price).HasColumnName("Price")
            .HasColumnType("decimal(19,2)");
        builder.Property(p => p.SocketType).HasColumnName("SocketType")
            .HasColumnType("tinyint");
        builder.Property(p => p.Status).HasColumnName("Status")
            .HasColumnType("tinyint");
        builder.Property(p => p.IsActive).HasColumnName("IsActive");

        builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
        builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
        builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy");
        builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(p => p.DeletedBy).HasColumnName("DeletedBy");
        builder.Property(p => p.DeletedAt).HasColumnName("DeletedAt");

        builder.HasOne(p => p.Station);
    }
}
