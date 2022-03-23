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
    public class GetRegisteredEmployeeData : IExecuteDataRequestAsync<EmployeeSearchRequest, List<Employees>>
    {

        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetRegisteredEmployeeData(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }
        public async Task<List<Employees>> ExecuteAsync(EmployeeSearchRequest employeeSearchRequest)
        {

            var regEmpData = await _PaymentAppDbContextQuery.Employees.
                Where(x =>
                (string.IsNullOrEmpty(employeeSearchRequest.FirstName) ? x.FirstName == x.FirstName : x.FirstName == employeeSearchRequest.FirstName)
                &&
                (string.IsNullOrEmpty(employeeSearchRequest.LastName) ? x.LastName == x.LastName : x.LastName == employeeSearchRequest.LastName)
              &&
               (string.IsNullOrEmpty(employeeSearchRequest.ADPFileNo) ? x.AdpFileNumber == x.AdpFileNumber : x.AdpFileNumber == employeeSearchRequest.ADPFileNo)
               &&
                (employeeSearchRequest.locationId == 0 ? x.LocationId == x.LocationId : x.LocationId == employeeSearchRequest.locationId)
                &&
                  (employeeSearchRequest.employeetypeId == 0 ? x.EmployeeTypeId == x.EmployeeTypeId : x.EmployeeTypeId == employeeSearchRequest.employeetypeId)
                  &&
                    (employeeSearchRequest.VisastatusID == 0 ? x.VisaStatusId == x.VisaStatusId : x.VisaStatusId == employeeSearchRequest.VisastatusID)
                ).ToListAsync();

            var empEnt = _mapper.Map<List<Employees>>(regEmpData);

            return empEnt;


        }
    }
}
