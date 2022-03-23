using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetEmployeeProjectById : IHandleQueryAsync<int, EmployeeProject>
    {
        private readonly IExecuteDataRequestAsync<int, EmployeeProject> _getEmployeeTypeProject;

        public GetEmployeeProjectById(IExecuteDataRequestAsync<int, EmployeeProject> getEmployeeProject)
        {
            _getEmployeeTypeProject = getEmployeeProject;
        }
        public async Task<EmployeeProject> ExecuteAsync(int id)
        {
            var employeeProject = await _getEmployeeTypeProject.ExecuteAsync(id);
            return employeeProject;
           
        }
    }
}
