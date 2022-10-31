using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilitaryManager.Core.Entities.DecreeDataEntity
{
    public class DecreeDataConfiguration : IEntityTypeConfiguration<DecreeData>
    {
        public void Configure(EntityTypeBuilder<DecreeData> builder)
        {
            builder.HasOne(x => x.TemplatePlaceholder)
                .WithMany(x => x.DecreeDatas)
                .HasForeignKey(x => x.TemplatePlaceholderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(decreeData => decreeData.Value)
                .HasColumnType("sql_variant")
                .IsRequired();
        }
    }
}
