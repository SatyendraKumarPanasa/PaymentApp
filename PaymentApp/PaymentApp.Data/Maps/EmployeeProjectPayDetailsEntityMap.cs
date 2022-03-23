using PaymentApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Maps
{
    public class EmployeeProjectPayDetailsEntityMap : IEntityTypeConfiguration<EmployeeProjectPayDetailsEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeProjectPayDetailsEntity> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("EmployeeProjectPayDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");

        }
    }
}
