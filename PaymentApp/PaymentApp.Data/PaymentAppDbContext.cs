using PaymentApp.Data.Entities;
using PaymentApp.Data.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data
{
   public abstract class PaymentAppDbContext<T> : DbContext
         where T : DbContext
    {
        public PaymentAppDbContext(DbContextOptions<T> options) :
            base(options)
        {
        }

        public DbSet<LocationEntity> Locations { get; set; } = null!;
        public DbSet<BenfitsEntity> Benfits { get; set; } = null!;
        public DbSet<ClientsEntity> clients { get; set; } = null!;
        public DbSet<EmployeeProjectEntity> EmployeeProjects { get; set; } = null!;

        public DbSet<EmployeesEntity> Employees { get; set; } = null!;

        public DbSet<EmployeeTypeEntity> EmployeeType { get; set; } = null!;

        public DbSet<EmployeeNotesEntity> EmployeeNotes { get; set; } = null!;
        public DbSet<EmployeeProjectPayDetailsEntity> EmployeeProjectPayDetails { get; set; } = null!;
        public DbSet<ProjectsEntity> Projects { get; set; } = null!;
        public DbSet<ProjectStatusEntity> ProjectStatus { get; set; } = null!;

        public DbSet<RolesEntity> Roles { get; set; } = null!;

        public DbSet<VendorsEntity> Vendors { get; set; } = null!;

        public DbSet<VisaStatusEntity> VisaStatus { get; set; } = null!;

        public DbSet<UsersEntity> Users { get; set; } = null!;

        public DbSet<SalaryTypeEntity> SalaryType { get; set; } = null!;

        public DbSet<PersonalinfoEntity> personalinfos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfiguration(new LocationEntityMap());

            modelBuilder.ApplyConfiguration(new BenfitsEntityMap());

            modelBuilder.ApplyConfiguration(new ClientsEntityMap());

            modelBuilder.ApplyConfiguration(new EmployeeProjectEntityMap());

            modelBuilder.ApplyConfiguration(new EmployeesEntityMap());

            modelBuilder.ApplyConfiguration(new EmployeeTypeEntityMap());

            modelBuilder.ApplyConfiguration(new EmployeeNotesEntityMap());

            modelBuilder.ApplyConfiguration(new EmployeeProjectPayDetailsEntityMap());

            modelBuilder.ApplyConfiguration(new ProjectsEntityMap());

            modelBuilder.ApplyConfiguration(new ProjectStatusEntityMap());

            modelBuilder.ApplyConfiguration(new RolesEntityMap());

            modelBuilder.ApplyConfiguration(new UsersEntityMap());

            modelBuilder.ApplyConfiguration(new VendorsEntityMap());

            modelBuilder.ApplyConfiguration(new VisaStatusEntityMap());

            modelBuilder.ApplyConfiguration(new PersonalinfoEntityMap());


        }
    }
}
