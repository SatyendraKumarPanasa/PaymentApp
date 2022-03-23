using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.Commands
{
   public class UpdateEmployeeByIdCommandHandler : IHandleCommandAsync<Employees, Response<Employees>>
    {
        private readonly IExecuteDataRequestAsync<Employees, Response<Employees>> _saveEmployeeDeatils;

        public UpdateEmployeeByIdCommandHandler(IExecuteDataRequestAsync<Employees, Response<Employees>> saveEmployeeDeatils)
        {
            _saveEmployeeDeatils = saveEmployeeDeatils;
        }

        public async Task<Response<Employees>> ExecuteAsync(Employees employees)
        {
            return await _saveEmployeeDeatils.ExecuteAsync(employees);
        }
    }
}
