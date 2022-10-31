using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.Entities.SignedPdfEntity
{
    public class SignedPdfConfiguration : IEntityTypeConfiguration<SignedPdf>
    {
        public void Configure(EntityTypeBuilder<SignedPdf> builder)
        {
            builder.Property(signedPdf => signedPdf.Path)
                   .IsRequired();

            builder.HasOne(signedPdf => signedPdf.Decree)
                   .WithOne(decree => decree.SignedPdf)
                   .HasForeignKey<SignedPdf>(signedPdf => signedPdf.Id);

            builder.Property(decree => decree.RowVersion)
               .IsRowVersion();
        }
    }
}
