using AutoMapper;
using dCaf.Core;
using Microsoft.EntityFrameworkCore;
using PaymentApp.Core.DomainModels;
using PaymentApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Commands
{
   public class UpdateEmployeesData : IExecuteDataRequestAsync<Employees, Response<Employees>>
    {
        private readonly PaymentAppDbContextCommand _PaymentAppDbContextCommand;
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;
        private readonly Response<Employees> _response;

        public UpdateEmployeesData(PaymentAppDbContextCommand PaymentAppDbContextCommand, PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextCommand = PaymentAppDbContextCommand;
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
            _response = new Response<Employees>();
        }
        public async Task<Response<Employees>> ExecuteAsync(Employees employees)
        {
            var empData = await _PaymentAppDbContextQuery.Employees
                                    .FirstOrDefaultAsync(x => x.Id == employees.Id);

            if (empData == null)
            {
                _response.Result = _mapper.Map<Employees>(empData);

                _response.AddError("Es201", "AdpFileNumber for this user is not there ");

                return _response;
            }
            else
            {
                var mapEmpData = _mapper.Map<EmployeesEntity>(employees);
                empData.AdpFileNumber = mapEmpData.AdpFileNumber;
                empData.DOJ = mapEmpData.DOJ;
                empData.DOL = mapEmpData.DOL;
                empData.FirstName = mapEmpData.FirstName;
                empData.LastName = mapEmpData.LastName;
                empData.VisaStatusId = mapEmpData.VisaStatusId;
                empData.MarkettingBy = mapEmpData.MarkettingBy;
                empData.LocationId = mapEmpData.LocationId;
                empData.ReferredBy = mapEmpData.ReferredBy;
                empData.EmployeeTypeId = mapEmpData.EmployeeTypeId;
                empData.H1wageDate = mapEmpData.H1wageDate;
                empData.PayrollStartDate = mapEmpData.PayrollStartDate;
                empData.Status = true;
                _PaymentAppDbContextCommand.Employees.Update(empData);

                await _PaymentAppDbContextCommand.SaveChangesAsync();

                _response.Result = _mapper.Map<Employees>(empData);
            }

            return _response;

        }
    }
}
