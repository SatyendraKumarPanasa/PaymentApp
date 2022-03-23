using PaymentApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Maps
{
    public class ProjectsEntityMap : IEntityTypeConfiguration<ProjectsEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectsEntity> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Projects");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");

        }
    }
}
