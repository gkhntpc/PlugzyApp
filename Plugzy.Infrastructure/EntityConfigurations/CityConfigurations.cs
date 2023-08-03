using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations;

public class CityConfigurations : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("City").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Name).HasColumnName("Name");
        builder.Property(p => p.IsActive).HasColumnName("IsActive");

        builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
        builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
        builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy");
        builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(p => p.DeletedBy).HasColumnName("DeletedBy");
        builder.Property(p => p.DeletedAt).HasColumnName("DeletedAt");

        builder.HasOne(p => p.Country);
        builder.HasMany(p => p.Counties);
    }
}
