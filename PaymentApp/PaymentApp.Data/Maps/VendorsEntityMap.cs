using PaymentApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Maps
{
    public class VendorsEntityMap : IEntityTypeConfiguration<VendorsEntity>
    {
        public void Configure(EntityTypeBuilder<VendorsEntity> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Vendors");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");

        }
    }
}
