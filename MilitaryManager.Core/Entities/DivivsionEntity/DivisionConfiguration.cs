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
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Address)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasMany(x => x.SubDivisions)
                .WithOne(x => x.Parent)
                .HasForeignKey(x => x.ParentId);
        }
    }
}