using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();
        builder.Property(p => p.FullName).HasColumnName("FullName")
            .HasColumnType("varchar(100)");
        builder.Property(p => p.Email).HasColumnName("Email")
            .HasColumnType("varchar(100)");
        builder.HasIndex(i => i.Email).IsUnique();
        builder.Property(p => p.PhoneNumber).HasColumnName("Phone")
            .HasColumnType("varchar(100)");
        builder.HasIndex(i => i.PhoneNumber).IsUnique();
        builder.Property(p => p.Type).HasColumnName("Type")
            .HasColumnType("tinyint");
        builder.Property(p => p.Status).HasColumnName("Status")
           .HasColumnType("tinyint");
        builder.Property(p => p.LastLogin).HasColumnName("LastLogin");

        builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
        builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
        builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy");
        builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(p => p.DeletedBy).HasColumnName("DeletedBy");
        builder.Property(p => p.DeletedAt).HasColumnName("DeletedAt");

        builder.HasMany(x => x.Favorite);
    }
}
