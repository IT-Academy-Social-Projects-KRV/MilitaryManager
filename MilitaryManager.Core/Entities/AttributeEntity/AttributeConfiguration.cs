using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilitaryManager.Core.Entities.AttributeEntity
{
    public class AttributeConfiguration : IEntityTypeConfiguration<Attribute>
    {
        public void Configure(EntityTypeBuilder<Attribute> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Type)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(x => x.AttributeType)
                .WithMany(x => x.Attributes)
                .HasForeignKey(x => x.Type);
        }
    }
}
