using AutoMapper;
using dCaf.Core;
using Microsoft.EntityFrameworkCore;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Queries
{
   public class GetAllEmployeeProjectsData : IExecuteDataRequestAsync<List<ListEmployeeProjects>>
    {

        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetAllEmployeeProjectsData(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }
        public async Task<List<ListEmployeeProjects>> ExecuteAsync()
        {
            List<ListEmployeeProjects> employeeprojects = new List<ListEmployeeProjects>();


            var res = (from empproj in _PaymentAppDbContextQuery.EmployeeProjects
                       join empData in _PaymentAppDbContextQuery.Employees on empproj.EmployeeId equals empData.Id
                       join projData in _PaymentAppDbContextQuery.Projects on empproj.ProjectId equals projData.Id
                       join venData in _PaymentAppDbContextQuery.Vendors on empproj.Vendor1Id equals venData.Id
                       join ven2Data in _PaymentAppDbContextQuery.Vendors on empproj.Vendor2Id equals ven2Data.Id
                       join clientData in _PaymentAppDbContextQuery.clients on empproj.EndClientId equals clientData.Id

                       select new
                       {
                           EmployeeProjectId = empproj.Id,
                           EmployeeId = empData.Id,
                           EmployeeName = empData.FirstName,
                           ProjectId = projData.Id,
                           ProjectName = projData.Name,
                           vendor1Id = venData.Id,
                           vendor1Name = venData.Name,
                           ClientId = clientData.Id,
                           ClientName = clientData.Name,
                           ProjectStatus = empproj.ProjectStatusID,
                           ProjStartDate = empproj.StartDate,
                           ProjEndDate = empproj.EndDate,
                           Vendor2Id = empproj.Vendor2Id,
                           vendor2Name =  venData.Name
                       }).ToListAsync();

            foreach( var et in res.Result)
            {
                ListEmployeeProjects employeeProject = new ListEmployeeProjects()
                {
                    EmployeeId = et.EmployeeId,
                    EmployeeName = et.EmployeeName,
                    EndClientId = et.ClientName,
                    EndDate = et.ProjEndDate,
                    Id = et.EmployeeProjectId,
                    ProjectId = et.ProjectId,
                    ProjectName = et.ProjectName,
                    ProjectStatusID = et.ProjectStatus,
                    Vendor1Id = et.vendor1Name,
                    Vendor2Id = et.vendor2Name
                    
                };
                employeeprojects.Add(employeeProject);
            }

            return employeeprojects;
        }
    }
}
