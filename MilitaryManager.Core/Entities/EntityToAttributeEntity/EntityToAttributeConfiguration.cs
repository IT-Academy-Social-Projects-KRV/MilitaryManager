using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilitaryManager.Core.Entities.EntityToAttributeEntity
{
    public class EntityToAttributeConfiguration : IEntityTypeConfiguration<EntityToAttribute>
    {
        public void Configure(EntityTypeBuilder<EntityToAttribute> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Value)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(x => x.Attribute)
                .WithMany(x => x.EntityToAttributes)
                .HasForeignKey(x => x.AttributeId);

            builder
                .HasOne(x => x.Entity)
                .WithMany(x => x.EntityToAttributes)
                .HasForeignKey(x => x.EntityId);
        }
    }
}
