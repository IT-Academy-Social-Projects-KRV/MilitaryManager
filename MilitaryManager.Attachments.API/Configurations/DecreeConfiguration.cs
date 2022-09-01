using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilitaryManager.Attachments.API.Entities;

namespace MilitaryManager.Attachments.API.Configurations
{
    public class DecreeConfiguration : IEntityTypeConfiguration<Decree>
    {
        public void Configure(EntityTypeBuilder<Decree> builder)
        {
            builder.Property(decree => decree.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(decree => decree.Path)
                .IsRequired();

            builder.Property(decree => decree.CreatedBy)
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(decree => decree.TimeStamp)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
