using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.Entities.AuditEntities.ChangeEntity
{
    public class ChangeConfiguration : IEntityTypeConfiguration<Change>
    {
        public void Configure(EntityTypeBuilder<Change> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.TableName)
                .IsRequired();

            builder
                .Property(x => x.RowId)
                .IsRequired();

            builder
                .Property(x => x.Date)
                .IsRequired();

            builder
                .Property(x => x.ChangeTypeCode)
                .IsRequired();

            builder
                .HasOne(x => x.Table)
                .WithMany(x => x.Changes)
                .HasForeignKey(x => x.TableName);

            builder
                .HasOne(x => x.ChangeType)
                .WithMany(x => x.Changes)
                .HasForeignKey(x => x.ChangeTypeCode);
        }
    }
}
