using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.Entities.AttributeTypeEntity
{
    public class AttributeTypeConfiguration : IEntityTypeConfiguration<AttributeType>
    {
        public void Configure(EntityTypeBuilder<AttributeType> builder)
        {
            builder
                .HasKey(x => x.Name);
        }
    }
}
