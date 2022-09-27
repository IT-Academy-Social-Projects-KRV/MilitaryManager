using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

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

            List<Template> templates = new List<Template>()
            {
                new Template()
                {
                    Id = 1,
                    Type = "Протокол",
                    Path = "data/document_templates/template_01.xml"
                }
            };

            builder.HasData(templates);
        }
    }
}
