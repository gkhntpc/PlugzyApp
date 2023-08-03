using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations;

public class ContentConfigurations : IEntityTypeConfiguration<Content>
{
    public void Configure(EntityTypeBuilder<Content> builder)
    {
        builder.ToTable("Content").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Key).HasColumnName("Key")
            .HasColumnType("varchar(100)");
        builder.Property(p => p.Value).HasColumnName("Value");
        builder.Property(p => p.Type).HasColumnName("Type")
            .HasColumnType("tinyint");
        builder.Property(p => p.Lang).HasColumnName("Lang")
            .HasColumnType("tinyint");
        builder.Property(p => p.IsActive).HasColumnName("IsActive");
    }
}
