using AutoMapper;
using dCaf.Core;
using PaymentApp.Data.Commands;
using PaymentApp.Data.Queries;
using PaymentApp.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data
{
    public static class RegisterDataLayer
    {
        public static IServiceCollection RegisterMemberCommandsAndQueries(this IServiceCollection services)
        {
            services.AddScoped<IExecuteDataRequestAsync<int, List<Location>>, GetMemberLocations>();

            services.AddScoped<IExecuteDataRequestAsync<int, Benfits>, GetEmployeeBenifits>();

            services.AddScoped<IExecuteDataRequestAsync<int, Clients>, GetClientById>();

            services.AddScoped<IExecuteDataRequestAsync<int, EmployeeType>, GetEmployeeTypeById>();

            services.AddScoped<IExecuteDataRequestAsync<int, Employees>, GetEmployeeById>();

            services.AddScoped<IExecuteDataRequestAsync<int, EmployeeProject>, GetEmployeeProjectById>();

            services.AddScoped<IExecuteDataRequestAsync<int, List<EmployeeNotes>>, GetEmployeeNotesDetailById>();

            services.AddScoped<IExecuteDataRequestAsync<int, List<EmployeeProjectPayDetails>>, GetEmployeesProjectPayDetailById>();

            services.AddScoped<IExecuteDataRequestAsync<int, List<Projects>>, GetProjectsById>();

            services.AddScoped<IExecuteDataRequestAsync<ProjectSearch, List<Projects>>, GetProjectsByProjectName>();

            services.AddScoped<IExecuteDataRequestAsync<int, ProjectStatus>, GetProjectStatusById>();

            services.AddScoped<IExecuteDataRequestAsync<int, Roles>, GetRolesById>();

            services.AddScoped<IExecuteDataRequestAsync<int, Users>, GetUserById>();

            services.AddScoped<IExecuteDataRequestAsync<int, Vendors>, GetVendorById>();

            services.AddScoped<IExecuteDataRequestAsync<int, VisaStatus>, GetVisaStatusById>();

            services.AddScoped<IExecuteDataRequestAsync<List<VisaStatus>>, GetAllVisaStatusData>();

            services.AddScoped<IExecuteDataRequestAsync<List<Vendors>>, GetAllVendorsData>();

            services.AddScoped<IExecuteDataRequestAsync<List<Location>>, GetAllLocationsData>();

            services.AddScoped<IExecuteDataRequestAsync<List<EmployeeType>>, GetAllEmployeeTypesData>();

            services.AddScoped<IExecuteDataRequestAsync<Employees, Response<Employees>>, SaveEmployeesData>();

            services.AddScoped<IExecuteDataRequestAsync<List<Employees>>, GetAllEmployeesData>();

            services.AddScoped<IExecuteDataRequestAsync<List<Projects>>, GetAllProjectsData>();

            services.AddScoped<IExecuteDataRequestAsync<List<SalaryType>>, GetAllSalaryTypesData>();

            services.AddScoped<IExecuteDataRequestAsync<List<ProjectStatus>>, GetAllProjectStatusData>();

            services.AddScoped<IExecuteDataRequestAsync<List<Roles>>, GetAllRolesData>();

            services.AddScoped<IExecuteDataRequestAsync<Location, Response<Location>>, SaveLocation>();

            services.AddScoped<IExecuteDataRequestAsync<Projects, Response<Projects>>, SaveProjectsData>();

            services.AddScoped<IExecuteDataRequestAsync<EmployeeSearchRequest, List<Employees>>, GetRegisteredEmployeeData>();


            services.AddScoped<IExecuteDataRequestAsync<LoginViewModel, LoginViewModel>, LoginDetailsData>();

            services.AddScoped<IExecuteDataRequestAsync<EmployeeProjectPayDetails, Response<EmployeeProjectPayDetails>>, SaveEmployeeprojectPayDetails>();

            services.AddScoped<IExecuteDataRequestAsync<EmployeeProject, Response<EmployeeProject>>, SaveEmployeeprojectsData>();

            services.AddScoped<IExecuteDataRequestAsync<Users, Response<Users>>, SaveUserDetailsData>();


            services.AddScoped<IExecuteDataRequestAsync<UserSearchRequest, List<Users>>, GetRegisteredUserData>();

            services.AddScoped<IExecuteDataRequestAsync<List<ListEmployeeProjects>>, GetAllEmployeeProjectsData>();

            services.AddScoped<IExecuteDataRequestAsync<EmployeeNotes, Response<EmployeeNotes>>, SaveEmployeeNotesData>();

            services.AddScoped<IExecuteDataRequestAsync<int, List<ListEmployeeProjects>>, GetEmployeeProjectsByEmployeeId>();

            services.AddScoped<IExecuteDataRequestAsync<Employees, Response<Employees>>, UpdateEmployeesData>();

            services.AddScoped<IExecuteDataRequestAsync<EmployeeProject, Response<EmployeeProject>>, UpdateEmployeeproject>();

            services.AddScoped<IExecuteDataRequestAsync<Projects, Response<Projects>>, UpdateProjectsData>();

            services.AddScoped<IExecuteDataRequestAsync<EmployeeNotes, Response<EmployeeNotes>>, UpdateEmployeeNotesData>();






            return services;
        }

        public static IServiceCollection RegisterEmployeeDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services
                    .AddDbContext<PaymentAppDbContextCommand>(options => options.UseSqlServer(configuration.GetConnectionString("PaymentAppDatabase")));
            services.AddDbContext<PaymentAppDbContextQuery>(
                 options => options.UseSqlServer(configuration.GetConnectionString("PaymentAppDatabaseReadonly"))
                                                 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            return services;
        }
    }
}
