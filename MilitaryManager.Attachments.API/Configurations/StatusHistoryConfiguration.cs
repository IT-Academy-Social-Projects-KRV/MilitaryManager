using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilitaryManager.Attachments.API.Entities;

namespace MilitaryManager.Attachments.API.Configurations
{
    public class StatusHistoryConfiguration : IEntityTypeConfiguration<StatusHistory>
    {
        public void Configure(EntityTypeBuilder<StatusHistory> builder)
        {
            builder.Property(statusHistory => statusHistory.PerformedBy)
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(statusHistory => statusHistory.TimeStamp)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
