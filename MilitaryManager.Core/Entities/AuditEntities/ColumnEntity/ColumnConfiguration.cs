using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.Entities.AuditEntities.ColumnEntity
{
    public class ColumnConfiguration : IEntityTypeConfiguration<Column>
    {
        public void Configure(EntityTypeBuilder<Column> builder)
        {
            builder
                .HasKey(x => x.Name);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .HasAlternateKey(x => new { x.Name, x.TableName });

            builder
                .HasOne(x => x.Table)
                .WithMany(x => x.Columns)
                .HasForeignKey(x => x.TableName);
        }
    }
}
