using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilitaryManager.Core.Entities.DivisionEntity;

namespace MilitaryManager.Core.Entities.EquipmentToSoldierEntity
{
    public class EquipmentToSoldierConfiguration : IEntityTypeConfiguration<EquipmentToSoldier>
    {
        public void Configure(EntityTypeBuilder<EquipmentToSoldier> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Equipment)
                .WithOne(x => x.EquipmentToSoldiers)
                .HasForeignKey<EquipmentToSoldier>(x => x.Id);

            builder
                .Property(x => x.GivenDate)
                .IsRequired();

            builder
                .HasOne(x => x.Unit)
                .WithMany(x => x.EquipmentToSoldiers)
                .HasForeignKey(x => x.UnitId);

            builder
                .HasOne(x => x.Warehouseman)
                .WithMany(x => x.EquipmentToWarehouseMan)
                .HasForeignKey(x => x.GivenById);

            builder
                .HasOne((System.Linq.Expressions.Expression<System.Func<EquipmentToSoldier, Division>>)(x => x.Division))
                .WithMany(x => x.EquipmentToSoldiers)
                .HasForeignKey(x => x.DivisionId);
        }
    }
}
