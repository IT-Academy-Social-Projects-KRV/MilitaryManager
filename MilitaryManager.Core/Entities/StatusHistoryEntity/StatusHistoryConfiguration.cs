using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilitaryManager.Core.Entities.StatusHistoryEntity
{
    public class StatusHistoryConfiguration : IEntityTypeConfiguration<StatusHistory>
    {
        public void Configure(EntityTypeBuilder<StatusHistory> builder)
        {
            builder.HasOne(statusHistory => statusHistory.OldStatus)
                   .WithMany(status => status.OldStatuses)
                   .HasForeignKey(statusHistory => statusHistory.OldStatusId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(statusHistory => statusHistory.NewStatus)
                   .WithMany(status => status.NewStatuses)
                   .HasForeignKey(statusHistory => statusHistory.NewStatusId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(statusHistory => statusHistory.PerformedBy)
                   .HasMaxLength(450)
                   .IsRequired();

            builder.Property(statusHistory => statusHistory.TimeStamp)
                   .HasColumnType("datetime2")
                   .IsRequired();
        }
    }
}
