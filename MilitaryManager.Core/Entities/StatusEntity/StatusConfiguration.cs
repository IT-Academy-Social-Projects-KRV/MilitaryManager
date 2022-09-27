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

            List<Status> statuses = new List<Status>()
            {
                new Status
                {
                    Id = 1,
                    Name = "Created"
                },
                new Status
                {
                    Id = 2,
                    Name = "Downloaded"
                },
                new Status
                {
                    Id = 3,
                    Name = "Signed"
                },
                new Status
                {
                    Id = 4,
                    Name = "Completed"
                },
            };

            builder.HasData(statuses);
        }
    }
}
