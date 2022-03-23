using PaymentApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Maps
{
    class EmployeeTypeEntityMap : IEntityTypeConfiguration<EmployeeTypeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeTypeEntity> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("EmployeeType");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");

        }
    }
}
