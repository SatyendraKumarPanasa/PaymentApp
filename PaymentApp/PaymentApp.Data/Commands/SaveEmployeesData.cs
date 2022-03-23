using AutoMapper;
using dCaf.Core;
using PaymentApp.Data.Entities;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PaymentApp.Data.Commands
{
   public class SaveEmployeesData : IExecuteDataRequestAsync<Employees, Response<Employees>>
    {
        private readonly PaymentAppDbContextCommand _PaymentAppDbContextCommand;
        private readonly IMapper _mapper;
        private readonly Response<Employees> _response;

        public SaveEmployeesData(PaymentAppDbContextCommand PaymentAppDbContextCommand, IMapper mapper)
        {
            _PaymentAppDbContextCommand = PaymentAppDbContextCommand;
            _mapper = mapper;
            _response = new Response<Employees>();
        }

        public async Task<Response<Employees>> ExecuteAsync(Employees employees)
        {
            var duplicateAdpNumber = await _PaymentAppDbContextCommand.Employees
                                    .FirstOrDefaultAsync(x => x.AdpFileNumber == employees.AdpFileNumber);

            if(duplicateAdpNumber != null)
            {
                _response.Result = _mapper.Map<Employees>(duplicateAdpNumber); ;

                _response.AddError("Es201", "AdpFileNumber  is already Registered");

                return _response;
            }
            else
            {
                var mapEmpData = _mapper.Map<EmployeesEntity>(employees);
                mapEmpData.Status = true;
                _PaymentAppDbContextCommand.Employees.Add(mapEmpData);

                await _PaymentAppDbContextCommand.SaveChangesAsync();

                _response.Result = _mapper.Map<Employees>(mapEmpData);
            }


            return _response;

        }
    }
}
