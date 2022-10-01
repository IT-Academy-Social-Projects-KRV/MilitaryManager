using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilitaryManager.Core.Entities.DivisionEntity;

namespace MilitaryManager.Core.Entities.EquipmentToUnitEntity
{
    public class EquipmentToUnitConfiguration : IEntityTypeConfiguration<UnitToEquipment>
    {
        public void Configure(EntityTypeBuilder<UnitToEquipment> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Equipment)
                .WithOne(x => x.UnitToEquipment)
                .HasForeignKey<UnitToEquipment>(x => x.Id);

            builder
                .Property(x => x.GivenDate)
                .IsRequired();

            builder
                .HasOne(x => x.Unit)
                .WithMany(x => x.UnitToEquipments)
                .HasForeignKey(x => x.UnitId);

            builder
                .HasOne(x => x.Warehouseman)
                .WithMany(x => x.EquipmentToWarehouseMan)
                .HasForeignKey(x => x.GivenById);

            builder
                .HasOne((System.Linq.Expressions.Expression<System.Func<UnitToEquipment, Division>>)(x => x.Division))
                .WithMany(x => x.UnitToEquipments)
                .HasForeignKey(x => x.DivisionId);
        }
    }
}
