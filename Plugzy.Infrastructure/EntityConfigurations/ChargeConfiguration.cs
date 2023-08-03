using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations;

public class ChargeConfiguration : IEntityTypeConfiguration<Charge>
{
    public void Configure(EntityTypeBuilder<Charge> builder)
    {
        builder.ToTable("Charge").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.StartDate).HasColumnName("StartDate");
        builder.Property(p => p.EndDate).HasColumnName("EndDate");
        builder.Property(p => p.CurrentType).HasColumnName("CurrentType")
            .HasColumnType("tinyint");
        builder.Property(p => p.Kw).HasColumnName("Kw")
            .HasColumnType("decimal(19,2)");
        builder.Property(p => p.Amount).HasColumnName("Amount")
            .HasColumnType("decimal(19,2)");
        builder.Property(p => p.SocketType).HasColumnName("SocketType")
            .HasColumnType("tinyint");

        builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
        builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
        builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy");
        builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(p => p.DeletedBy).HasColumnName("DeletedBy");
        builder.Property(p => p.DeletedAt).HasColumnName("DeletedAt");

        builder.HasOne(p => p.User);
        builder.HasOne(p => p.Station).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(p => p.Socket);
    }
}
