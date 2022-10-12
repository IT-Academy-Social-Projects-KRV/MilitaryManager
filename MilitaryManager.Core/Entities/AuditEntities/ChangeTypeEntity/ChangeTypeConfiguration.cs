using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.Entities.AuditEntities.ChangeTypeEntity
{
    public class ChangeTypeConfiguration : IEntityTypeConfiguration<ChangeType>
    {
        public void Configure(EntityTypeBuilder<ChangeType> builder)
        {
            builder
                .HasKey(x => x.Code);

            builder
                .Property(x => x.Name)
                .IsRequired();
        }
    }
}
