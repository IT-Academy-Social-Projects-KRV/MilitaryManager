using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilitaryManager.Core.Entities.EquipmentToSoldierEntity
{
    public class EquipmentToSoldierConfiguration : IEntityTypeConfiguration<EquipmentToSoldier>
    {
        public void Configure(EntityTypeBuilder<EquipmentToSoldier> builder)
        {
            builder
                .HasKey(x => x.EquipmentId);

            builder
                .HasOne(x => x.Equipment)
                .WithOne(x => x.EquipmentToSoldiers);

            builder
                .Property(x => x.GivenDate)
                .IsRequired();

            builder
                .HasOne(x => x.Soldier)
                .WithMany(x => x.EquipmentToSoldiers)
                .HasForeignKey(x => x.SoldierId);

            builder
                .HasOne(x => x.Warehouseman)
                .WithMany(x => x.EquipmentToWarehouseMan)
                .HasForeignKey(x => x.GivenById);

            builder
                .HasOne(x => x.Unit)
                .WithMany(x => x.EquipmentToSoldiers)
                .HasForeignKey(x => x.UnitId);
        }
    }
}
