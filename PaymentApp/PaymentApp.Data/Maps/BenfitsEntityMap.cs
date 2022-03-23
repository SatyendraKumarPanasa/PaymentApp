using PaymentApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace PaymentApp.Data.Maps
{
    public class BenfitsEntityMap : IEntityTypeConfiguration<BenfitsEntity>
    {
        public void Configure(EntityTypeBuilder<BenfitsEntity> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Benfits");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");

        }
    }
}
