using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilitaryManager.Core.Entities.UnitEntity
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Address)
                .IsRequired();

            builder
                .HasMany(x => x.SubUnits)
                .WithOne(x => x.Parent)
                .HasForeignKey(x => x.ParentId);
        }
    }
}
