using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.Commands
{
    public class SaveEmployeeProjectsCommandHandler : IHandleCommandAsync<EmployeeProject, Response<EmployeeProject>>
    {

        private readonly IExecuteDataRequestAsync<EmployeeProject, Response<EmployeeProject>> _saveEmpProject;

        public SaveEmployeeProjectsCommandHandler(IExecuteDataRequestAsync<EmployeeProject, Response<EmployeeProject>> saveEmpProject)
        {
            _saveEmpProject = saveEmpProject;
        }
        public async Task<Response<EmployeeProject>> ExecuteAsync(EmployeeProject employeeProject)
        {
            return await _saveEmpProject.ExecuteAsync(employeeProject);
        }
    }
}
