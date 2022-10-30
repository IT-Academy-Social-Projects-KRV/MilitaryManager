using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilitaryManager.Core.Entities.AuditEntities.ChangeEntity;
using MilitaryManager.Core.Entities.AuditEntities.ChangeTypeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.Entities.AuditEntities.ChangeValueEntity
{
    public class ChangeValueConfiguration : IEntityTypeConfiguration<ChangeValue>
    {
        public void Configure(EntityTypeBuilder<ChangeValue> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.ChangeId)
                .IsRequired();

            builder
                .Property(x => x.ColumnName)
                .IsRequired();

            builder
                .HasOne(x => x.Change)
                .WithMany(x => x.ChangeValues)
                .HasForeignKey(x => x.ChangeId);

            builder
                .HasOne(x => x.Column)
                .WithMany(x => x.ChangeValues)
                .HasForeignKey(x => x.ColumnName)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
