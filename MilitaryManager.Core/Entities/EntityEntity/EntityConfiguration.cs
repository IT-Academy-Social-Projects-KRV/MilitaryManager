using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilitaryManager.Core.Entities.EntityEntity
{
    public class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.RegNum)
                .IsRequired();
        }
    }
}
