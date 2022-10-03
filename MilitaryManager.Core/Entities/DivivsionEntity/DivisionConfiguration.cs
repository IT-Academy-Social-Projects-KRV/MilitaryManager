using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilitaryManager.Core.Entities.DivisionEntity
{
    public class DivisionConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
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
<<<<<<< HEAD
                .HasMany(x => x.SubDivision)
=======
                .HasMany(x => x.SubDivisions)
>>>>>>> develop
                .WithOne(x => x.Parent)
                .HasForeignKey(x => x.ParentId);
        }
    }
}
