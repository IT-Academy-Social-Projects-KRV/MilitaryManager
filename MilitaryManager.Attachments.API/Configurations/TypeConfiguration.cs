using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilitaryManager.Attachments.API.Entities;

namespace MilitaryManager.Attachments.API.Configurations
{
    public class TypeConfiguration : IEntityTypeConfiguration<Type>
    {
        public void Configure(EntityTypeBuilder<Type> builder)
        {
            builder.Property(type => type.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
