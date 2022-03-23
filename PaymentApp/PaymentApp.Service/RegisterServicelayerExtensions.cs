using dCaf.Core;
using PaymentApp.Service.Commands;
using PaymentApp.Service.QueryHandlers;
using PaymentApp.Core.DomainModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeePortal.Service.Commands;

namespace PaymentApp.Service
{
    public static class RegisterServicelayerExtensions
    {
        public static IServiceCollection RegisterApiHandlers(this IServiceCollection services)
        {
            services.AddTransient<IHandleQueryAsync<int, List<Location>>, GetLocationsByIdQueryHandler>();

            services.AddTransient<IHandleQueryAsync<int, Benfits>, GetBenifitByIdQueryHandler>();

            services.AddTransient<IHandleQueryAsync<int, Clients>, GetClientByIdQueryHandler>();

            services.AddTransient<IHandleQueryAsync<int, Employees>, GetEmployeeByIdQueryHandler>();

            services.AddTransient<IHandleQueryAsync<int, EmployeeType>, GetEmployeeTypeByIdQueryHandler>();

            services.AddTransient<IHandleQueryAsync<int, List<EmployeeNotes>>, GetEmployeeNotesDetailByIdQueryHandler>();

            services.AddTransient<IHandleQueryAsync<int, List<EmployeeProjectPayDetails>>, GetEmployeesProjectPayDetailByIdQueryHandler>();

            services.AddTransient<IHandleQueryAsync<int, List<Projects>>, GetProjectsByIdQueryHandler>();

            services.AddTransient<IHandleQueryAsync<ProjectSearch, List<Projects>>, GetProjectsByProjectNameQueryHandler>();

            services.AddTransient<IHandleQueryAsync<int, ProjectStatus>, GetProjectStatusByIdQueryHandler>();

            services.AddTransient<IHandleQueryAsync<int, Roles>, GetRolesByIdQueryHandler>();

            services.AddTransient<IHandleQueryAsync<int, Users>, GetUserByIdQueryHandler>();

            services.AddTransient<IHandleQueryAsync<int, Vendors>, GetVendorByIdQueryHandler>();

            services.AddTransient<IHandleQueryAsync<int, VisaStatus>, GetVisaStatusQueryHandler>();

            services.AddTransient<IHandleQueryAsync<List<VisaStatus>>, GetAllVisaStatusQueryHandler>();

            services.AddTransient<IHandleQueryAsync<List<Vendors>>, GetAllVendorsQueryHandler>();

            services.AddTransient<IHandleQueryAsync<List<Location>>, GetAllLocationsQueryHandler>();

            services.AddTransient<IHandleQueryAsync<List<EmployeeType>>, GetAllEmployeeTypesQueryHandler>();

            services.AddTransient<IHandleCommandAsync<Employees, Response<Employees>>, SaveEmployeeDetailsCommandHandler>();

            services.AddTransient<IHandleQueryAsync<List<Employees>>, GetAllEmployeesQueryHandler>();

            services.AddTransient<IHandleQueryAsync<List<Projects>>, GetAllProjectsQueryHandler>();

            services.AddTransient<IHandleQueryAsync<List<SalaryType>>, GetAllSalaryTypesQueryHandler>();

            services.AddTransient<IHandleQueryAsync<List<ProjectStatus>>, GetAllProjectStatusQueryHandler>();

            services.AddTransient<IHandleQueryAsync<List<Roles>>, GetAllRolesQueryHandler>();

            services.AddTransient<IHandleCommandAsync<Location, Response<Location>>, SaveLocationCommandHandler>();

            services.AddTransient<IHandleCommandAsync<Projects, Response<Projects>>, SaveProjectDetailsCommandHandler>();

            services.AddTransient<IHandleCommandAsync<LoginViewModel, LoginViewModel>, LoginDetailsCommandHandler>();

            services.AddTransient<IHandleQueryAsync<EmployeeSearchRequest, List<Employees>>, RegisteredEmployeeSearchRequestQueryHandler>();

            services.AddTransient<IHandleCommandAsync<EmployeeProjectPayDetails, Response<EmployeeProjectPayDetails>>, SaveEmployeeProjectsPayDetailsCommandHandler>();

            services.AddTransient<IHandleCommandAsync<EmployeeProject, Response<EmployeeProject>>, SaveEmployeeProjectsCommandHandler>();

            services.AddTransient<IHandleCommandAsync<Users, Response<Users>>, SaveUserDetailsCommandHandler>();


            services.AddTransient<IHandleQueryAsync<UserSearchRequest, List<Users>>, RegisteredUserSearchRequestQueryHandler>();

            services.AddTransient<IHandleQueryAsync<List<ListEmployeeProjects>>, GetAllEmployeeProjectsQueryHandler>();

            services.AddTransient<IHandleCommandAsync<EmployeeNotes, Response<EmployeeNotes>>, SaveEmployeeNotesCommandHandler>();

            services.AddTransient<IHandleQueryAsync<int, List<ListEmployeeProjects>>, GetProjectsByEmployeeIdQueryHandler>();

            services.AddTransient<IHandleCommandAsync<Employees, Response<Employees>>, UpdateEmployeeByIdCommandHandler>();

            services.AddTransient<IHandleCommandAsync<EmployeeProject, Response<EmployeeProject>>, UpdateEmployeeprojectCommandHandler>();

            services.AddTransient<IHandleCommandAsync<Projects, Response<Projects>>, UpdateProjectsDetailsCommandHandler>();

            services.AddTransient<IHandleCommandAsync<EmployeeNotes, Response<EmployeeNotes>>, UpdateEmployeeNotesCommandHandler>();








            return services;
        }
    }
}
