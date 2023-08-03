using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations;

public class StationConfigurations : IEntityTypeConfiguration<Station>
{
    public void Configure(EntityTypeBuilder<Station> builder)
    {
        builder.ToTable("Station").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Number).HasColumnName("Number")
            .HasColumnType("varchar(100)");
        builder.Property(p => p.Name).HasColumnName("Name")
            .HasColumnType("varchar(100)");
        builder.Property(p => p.Address).HasColumnName("Address")
            .HasColumnType("varchar(200)");
        builder.Property(p => p.Latitude).HasColumnName("Latitude")
            .HasColumnType("varchar(200)");
        builder.Property(p => p.Longitude).HasColumnName("Longitude")
            .HasColumnType("varchar(200)");
        builder.Property(p => p.Status).HasColumnName("Status")
            .HasColumnType("tinyint");   
        builder.Property(p => p.IsIndividualPricing).HasColumnName("IsIndividualPricing");
        builder.Property(p => p.IsActive).HasColumnName("IsActive");

        builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
        builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
        builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy");
        builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(p => p.DeletedBy).HasColumnName("DeletedBy");
        builder.Property(p => p.DeletedAt).HasColumnName("DeletedAt");

        builder.HasOne(p => p.Brand);
        builder.HasOne(p => p.Country).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(p => p.City).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(p => p.County).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(p => p.Sockets);
    }
}
