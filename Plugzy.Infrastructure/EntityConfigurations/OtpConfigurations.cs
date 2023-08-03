using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations;

public class OtpConfigurations : IEntityTypeConfiguration<Otp>
{
    public void Configure(EntityTypeBuilder<Otp> builder)
    {
        builder.ToTable("OTP").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Code).HasColumnName("Code")
            .HasColumnType("varchar(100)");
        builder.Property(p => p.ValidTill).HasColumnName("ValidTill");
        builder.Property(p => p.Phone).HasColumnName("Phone")
            .HasColumnType("varchar(100)");
        builder.Property(p => p.Attempts).HasColumnName("Attempts")
            .HasColumnType("tinyint");
        builder.Property(p => p.IsActive).HasColumnName("IsActive");
        builder.Property(p => p.LoginTime).HasColumnName("LoginTime");

        builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
        builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
        builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy");
        builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(p => p.DeletedBy).HasColumnName("DeletedBy");
        builder.Property(p => p.DeletedAt).HasColumnName("DeletedAt");
    }
}
