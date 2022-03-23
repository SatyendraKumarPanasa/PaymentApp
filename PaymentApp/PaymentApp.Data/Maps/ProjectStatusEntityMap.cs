using PaymentApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Maps
{
    public class ProjectStatusEntityMap : IEntityTypeConfiguration<ProjectStatusEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectStatusEntity> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("ProjectStatus");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");

        }
    }
}
