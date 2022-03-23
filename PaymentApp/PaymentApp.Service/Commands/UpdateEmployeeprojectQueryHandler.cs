using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.Commands
{
   public class UpdateEmployeeprojectCommandHandler : IHandleCommandAsync<EmployeeProject, Response<EmployeeProject>>
    {
        private readonly IExecuteDataRequestAsync<EmployeeProject, Response<EmployeeProject>> _updateemployeeproject;

        public UpdateEmployeeprojectCommandHandler(IExecuteDataRequestAsync<EmployeeProject, Response<EmployeeProject>> updateemployeeproject)
        {
            _updateemployeeproject = updateemployeeproject;
        }

        public async Task<Response<EmployeeProject>> ExecuteAsync(EmployeeProject employeeProject)
        {
            return await _updateemployeeproject.ExecuteAsync(employeeProject);
        }
    }
}
