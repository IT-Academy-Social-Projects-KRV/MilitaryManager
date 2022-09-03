using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilitaryManager.Core.Entities.SoldierEntity
{
    public class SoldierConfiguration : IEntityTypeConfiguration<Soldier>
    {
        public void Configure(EntityTypeBuilder<Soldier> builder)
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
                .HasOne(x => x.Unit)
                .WithMany(x => x.Soldiers)
                .HasForeignKey(x => x.UnitId);

            builder
                .HasOne(x => x.Rank)
                .WithMany(x => x.Soldiers)
                .HasForeignKey(x => x.RankId);

            builder
                .HasOne(x => x.Position)
                .WithMany(x => x.Soldiers)
                .HasForeignKey(x => x.PositionId);

            builder
                .HasMany(x => x.SubSoldiers)
                .WithOne(x => x.Patronymic)
                .HasForeignKey(x => x.PatronymicId);
        }
    }
}
