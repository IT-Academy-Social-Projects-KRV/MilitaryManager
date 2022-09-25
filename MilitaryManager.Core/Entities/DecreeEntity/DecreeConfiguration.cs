using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilitaryManager.Core.Entities.DecreeEntity
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
                   .HasColumnType("datetime2")
                   .IsRequired();
        }
    }
}
