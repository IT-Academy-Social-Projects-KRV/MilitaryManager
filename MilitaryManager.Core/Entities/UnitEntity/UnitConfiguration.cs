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
                .Property(x => x.LastName)
                .IsRequired();

            builder
                .Property(x => x.FirstName)
                .IsRequired();

            builder
                .HasOne(x => x.Division)
                .WithMany(x => x.Units)
                .HasForeignKey(x => x.DivisionId);

            builder
                .HasOne(x => x.Rank)
                .WithMany(x => x.Units)
                .HasForeignKey(x => x.RankId);

            builder
                .HasOne(x => x.Position)
                .WithMany(x => x.Units)
                .HasForeignKey(x => x.PositionId);

            builder
                .HasMany(x => x.SubUnits)
                .WithOne(x => x.Parent)
                .HasForeignKey(x => x.ParentId);
        }
    }
}
