using AutoMapper;
using PaymentApp.Data.Entities;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Mappers
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<LocationEntity, Location>().ReverseMap();
            CreateMap<BenfitsEntity, Benfits>().ReverseMap();
            CreateMap<ClientsEntity, Clients>().ReverseMap();
            CreateMap<EmployeeProject, EmployeeProjectEntity>()
                          .ForMember(dest => dest.Vendor1Id, src => src.Ignore())
                          .ForMember(dest => dest.Vendor2Id, src => src.Ignore())
                          .ForMember(dest => dest.EndClientId, src => src.Ignore()).ReverseMap();
            CreateMap<EmployeesEntity, Employees>().ReverseMap();
            CreateMap<EmployeeTypeEntity, EmployeeType>().ReverseMap();
            CreateMap<EmployeeNotesEntity, EmployeeNotes>().ReverseMap();
            CreateMap<EmployeeProjectPayDetailsEntity, EmployeeProjectPayDetails>().ReverseMap();
            CreateMap<ProjectsEntity, Projects>().ReverseMap();
            CreateMap<ProjectStatusEntity, ProjectStatus>().ReverseMap();
            CreateMap<RolesEntity, Roles>().ReverseMap();
            CreateMap<UsersEntity, Users>().ReverseMap();
            CreateMap<VendorsEntity, Vendors>().ReverseMap();
            CreateMap<VisaStatusEntity, VisaStatus>().ReverseMap();
            CreateMap<SalaryTypeEntity, SalaryType>().ReverseMap();
            CreateMap<PersonalinfoEntity, Personalinfo>().ReverseMap();
        }
    }
}
