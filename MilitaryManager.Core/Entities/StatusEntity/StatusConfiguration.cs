using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace MilitaryManager.Core.Entities.StatusEntity
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.Property(status => status.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
