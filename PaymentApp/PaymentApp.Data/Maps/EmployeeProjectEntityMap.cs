using PaymentApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace PaymentApp.Data.Maps
{
    public class EmployeeProjectEntityMap : IEntityTypeConfiguration<EmployeeProjectEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeProjectEntity> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("EmployeeProjects");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(x => x.ProjectId).HasColumnName("ProjectId");
            builder.Property(x => x.Vendor1Id).HasColumnName("Vendor1Id");
            builder.Property(x => x.Vendor2Id).HasColumnName("Vendor2Id");
            builder.Property(x => x.EndClientId).HasColumnName("EndClientId");
            builder.Property(x => x.StartDate).HasColumnName("StartDate");
            builder.Property(x => x.EndDate).HasColumnName("EndDate");
            builder.Ignore(x => x.projects);
            builder.Ignore(x => x.Employees);
            builder.Ignore(x => x.vendors);
            builder.Ignore(x => x.clients);

            builder.HasOne(x => x.Employees!)
               .WithOne(g => g.EmployeeProjects!)
               .HasForeignKey<EmployeeProjectEntity>(x => x.Id);

            builder.HasOne(x => x.projects!)
           .WithOne(g => g.EmployeeProjects!)
           .HasForeignKey<EmployeeProjectEntity>(x => x.Id);

            builder.HasOne(x => x.vendors!)
           .WithOne(g => g.EmployeeProjects!)
           .HasForeignKey<EmployeeProjectEntity>(x => x.Id);

            builder.HasOne(x => x.clients!)
        .WithOne(g => g.EmployeeProjects!)
        .HasForeignKey<EmployeeProjectEntity>(x => x.Id);



        }
    }
}
