using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilitaryManager.Core.Entities.TemplatePlaceholderEntity
{
    public class TemplatePlaceholderConfiguration : IEntityTypeConfiguration<TemplatePlaceholder>
    {
        public void Configure(EntityTypeBuilder<TemplatePlaceholder> builder)
        {
            builder.Property(templatePlaceholder => templatePlaceholder.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
