using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilitaryManager.Core.Entities.UnitEntity
{
    public class UnitUserConfiguration : IEntityTypeConfiguration<UnitUser>
    {
        public void Configure(EntityTypeBuilder<UnitUser> builder)
        {
            builder
               .Property(x => x.UserId)
               .HasMaxLength(450)
               .IsRequired();
        }
    }
}
