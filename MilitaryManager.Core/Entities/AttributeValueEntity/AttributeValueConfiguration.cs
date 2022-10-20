using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.Entities.AttributeValueEntity
{
    public class AttributeValueConfiguration : IEntityTypeConfiguration<AttributeValue>
    {
        public void Configure(EntityTypeBuilder<AttributeValue> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Value)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(x => x.Attribute)
                .WithMany(x => x.AttributeValues)
                .HasForeignKey(x => x.AttributeId);
        }
    }
}
