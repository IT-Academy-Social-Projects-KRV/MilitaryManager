using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilitaryManager.Core.Entities.TemplateEntity
{
    public class TemplateConfiguration : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.Property(template => template.Type)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(template => template.Path)
                .IsRequired();
        }
    }
}
