using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilitaryManager.Core.Entities.ProfileEntity
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Value)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(x => x.Attribute)
                .WithMany(x => x.Profiles)
                .HasForeignKey(x => x.AttributeId);

            builder
                .HasOne(x => x.Unit)
                .WithMany(x => x.Profiles)
                .HasForeignKey(x => x.UnitId);
        }
    }
}
