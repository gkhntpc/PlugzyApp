using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations
{
    public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(b => b.Title).HasMaxLength(100);
            builder.Property(b => b.Description).HasMaxLength(1000);
        }
    }
}
