using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilitaryManager.Attachments.API.Entities;

namespace MilitaryManager.Attachments.API.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.Property(status => status.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
