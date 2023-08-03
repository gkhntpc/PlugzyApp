using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations;

public class PriceConfigurations : IEntityTypeConfiguration<Price>
{
    public void Configure(EntityTypeBuilder<Price> builder)
    {
        builder.ToTable("Price").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.CurrentType).HasColumnName("CurrentType")
            .HasColumnType("tinyint");
        builder.Property(p => p.KwStart).HasColumnName("KwStart")
            .HasColumnType("decimal(19,2)");
        builder.Property(p => p.KwFinish).HasColumnName("KwFinish")
            .HasColumnType("decimal(19,2)");
        builder.Property(p => p.SocketType).HasColumnName("SocketType")
            .HasColumnType("tinyint");
        builder.Property(p => p.PriceAmount).HasColumnName("PriceAmount")
            .HasColumnType("decimal(19,2)");

        builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
        builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
        builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy");
        builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(p => p.DeletedBy).HasColumnName("DeletedBy");
        builder.Property(p => p.DeletedAt).HasColumnName("DeletedAt");

        builder.HasOne(p => p.Brand);
    }
}
